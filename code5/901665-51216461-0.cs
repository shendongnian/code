    /*
    * Licensed to the Apache Software Foundation (ASF) under one or more
    * contributor license agreements.  See the NOTICE file distributed with
    * this work for additional information regarding copyright ownership.
    * The ASF licenses this file to You under the Apache License, Version 2.0
    * (the "License"); you may not use this file except in compliance with
    * the License.  You may obtain a copy of the License at
    *
    *     http://www.apache.org/licenses/LICENSE-2.0
    *
    * Unless required by applicable law or agreed to in writing, software
    * distributed under the License is distributed on an "AS IS" BASIS,
    * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    * See the License for the specific language governing permissions and
    * limitations under the License.
    */
    
    using System;
    using System.Collections.Generic;
    using Lucene.Net.Index;
    using Lucene.Net.Util;
    
    namespace Lucene.Net.Search
    {
        public class DuplicateFilter : Filter
        {
            public static int KM_USE_FIRST_OCCURRENCE = 1;
            public static int KM_USE_LAST_OCCURRENCE = 2;
            public static int PM_FAST_INVALIDATION = 2;
            public static int PM_FULL_VALIDATION = 1;
            private string fieldName;
    
            /*
             * KeepMode determines which document id to consider as the master, all others being
             * identified as duplicates. Selecting the "first occurrence" can potentially save on IO.
             */
            private int keepMode = KM_USE_FIRST_OCCURRENCE;
            /*
             * "Full" processing mode starts by setting all bits to false and only setting bits
             * for documents that contain the given field and are identified as none-duplicates.
    
             * "Fast" processing sets all bits to true then unsets all duplicate docs found for the
             * given field. This approach avoids the need to read TermDocs for terms that are seen
             * to have a document frequency of exactly "1" (i.e. no duplicates). While a potentially
             * faster approach , the downside is that bitsets produced will include bits set for
             * documents that do not actually contain the field given.
             *
             */
            private int processingMode = PM_FULL_VALIDATION;
    
            private object SetupLock = new object();
    
            public DuplicateFilter(string fieldName) : this(fieldName, KM_USE_LAST_OCCURRENCE, PM_FULL_VALIDATION)
            {
            }
    
            public DuplicateFilter(string fieldName, int keepMode, int processingMode)
            {
                this.fieldName = fieldName;
                this.keepMode = keepMode;
                this.processingMode = processingMode;
            }
    
            public string FieldName
            {
                get => fieldName;
                set => fieldName = value;
            }
    
            public int KeepMode
            {
                get => keepMode;
                set => keepMode = value;
            }
    
            public int ProcessingMode
            {
                get => processingMode;
                set => processingMode = value;
            }
    
            private IDictionary<string, (OpenBitSet Filtered, OpenBitSet Hit)> SegmentBits
            {
                get;
                set;
            } = new Dictionary<string, (OpenBitSet Filtered, OpenBitSet Hit)>();
    
            private bool SetupComplete
            {
                get;
                set;
            } = false;
    
            public override bool Equals(object obj)
            {
                if (this == obj) {
                    return true;
                }
                if ((obj == null) || (obj.GetType() != GetType())) {
                    return false;
                }
                var other = (DuplicateFilter)obj;
                return keepMode == other.keepMode &&
                processingMode == other.processingMode &&
                    (fieldName == other.fieldName || (fieldName != null && fieldName.Equals(other.fieldName)));
            }
    
            public override DocIdSet GetDocIdSet(IndexReader reader)
            {
                if (processingMode == PM_FAST_INVALIDATION) {
                    return FastBits(reader);
                } else {
                    return CorrectBits(reader);
                }
            }
    
            public override int GetHashCode()
            {
                var hash = 217;
                hash = 31 * hash + keepMode;
                hash = 31 * hash + processingMode;
                hash = 31 * hash + fieldName.GetHashCode();
                return hash;
            }
    
            private OpenBitSet CorrectBits(IndexReader reader)
            {
                SetupCorrect(reader);
                return SegmentBits[((SegmentReader)reader).GetSegmentName()].Filtered;
            }
    
            private OpenBitSet FastBits(IndexReader reader)
            {
                throw new NotImplementedException();
            }
    
            private void SetupCorrect(IndexReader reader)
            {
                lock (SetupLock) {
                    if (!SetupComplete) {
                        // Get segment readers and bitsets.
                        var segmentReaders = new Dictionary<string, SegmentReader>();
                        var sis = new SegmentInfos();
                        sis.Read(reader.Directory());
                        foreach (SegmentInfo si in sis) {
                            var r = SegmentReader.Get(true, si, 1);
                            segmentReaders.Add(si.name, r);
                            SegmentBits.Add(si.name, (new OpenBitSet(r.MaxDoc()), new OpenBitSet(r.MaxDoc())));
                        }
                        // Determine duplicates across segments.
                        foreach (var outerKvp in segmentReaders) {
                            var startTerm = new Term(fieldName);
                            var te = outerKvp.Value.Terms(startTerm);
                            if (te != null) {
                                var currTerm = te.Term();
                                while ((currTerm != null) && (currTerm.Field() == startTerm.Field())) {
                                    var set = false;
                                    var lastKey = outerKvp.Key;
                                    var lastDoc = -1;
                                    foreach (var innerKvp in segmentReaders) {
                                        var td = innerKvp.Value.TermDocs(currTerm);
                                        if (td.Next()) {
                                            var doc = td.Doc();
                                            if (SegmentBits[innerKvp.Key].Hit.Get(doc)) {
                                                // Term has already been hit; skip it.
                                                set = true;
                                                continue;
                                            }
                                            // Keep track of which terms have already been hit.
                                            SegmentBits[innerKvp.Key].Hit.Set(doc);
                                            if (set) {
                                                // Only need to set the first term as hit in each segment.
                                                continue;
                                            } else if (keepMode == KM_USE_FIRST_OCCURRENCE) {
                                                SegmentBits[innerKvp.Key].Filtered.Set(doc);
                                                set = true;
                                            } else {
                                                do {
                                                    lastDoc = td.Doc();
                                                    lastKey = innerKvp.Key;
                                                } while (td.Next());
                                            }
                                        }
                                    }
                                    if (!set && keepMode == KM_USE_LAST_OCCURRENCE) {
                                        SegmentBits[lastKey].Filtered.Set(lastDoc);
                                    }
                                    if (!te.Next()) {
                                        break;
                                    }
                                    currTerm = te.Term();
                                }
                            }
                        }
                        // Mark setup as complete.
                        SetupComplete = true;
                    }
                }
            }
        }
    }
