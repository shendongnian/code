    /**
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
    // Ported to C# from Java source at http://grepcode.com/file/repo1.maven.org/maven2/org.apache.lucene/lucene-misc/3.0.3/org/apache/lucene/queryParser/complexPhrase/ComplexPhraseQueryParser.java
    
    using Lucene.Net.Analysis;
    using Lucene.Net.Index;
    
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Search.Spans;
    using System;
    using System.Collections.Generic;
    
    using Version = Lucene.Net.Util.Version;
    
    public class ComplexPhraseQueryParser : QueryParser
    {
        private List<ComplexPhraseQuery> complexPhrases = null;
    
        private Boolean isPass2ResolvingPhrases;
    
        private ComplexPhraseQuery currentPhraseQuery = null;
    
        public ComplexPhraseQueryParser(Version matchVersion, String f, Analyzer a) : base(matchVersion, f, a) { }
    
    
    
        protected override Query GetFieldQuery(String field, String queryText, int slop)
        {
            ComplexPhraseQuery cpq = new ComplexPhraseQuery(field, queryText, slop);
            complexPhrases.Add(cpq); // add to list of phrases to be parsed once
            // we
            // are through with this pass
            return cpq;
        }
    
    
        public override Query Parse(String query)
        {
            if (isPass2ResolvingPhrases)
            {
                RewriteMethod oldMethod = MultiTermRewriteMethod;
                try
                {
                    // Temporarily force BooleanQuery rewrite so that Parser will
                    // generate visible
                    // collection of terms which we can convert into SpanQueries.
                    // ConstantScoreRewrite mode produces an
                    // opaque ConstantScoreQuery object which cannot be interrogated for
                    // terms in the same way a BooleanQuery can.
                    // QueryParser is not guaranteed threadsafe anyway so this temporary
                    // state change should not
                    // present an issue
                    MultiTermRewriteMethod = MultiTermQuery.SCORING_BOOLEAN_QUERY_REWRITE;
                    return base.Parse(query);
                }
                finally
                {
                    MultiTermRewriteMethod = oldMethod;
                }
            }
    
            // First pass - parse the top-level query recording any PhraseQuerys
            // which will need to be resolved
            complexPhrases = new List<ComplexPhraseQuery>();
            Query q = base.Parse(query);
    
            // Perform second pass, using this QueryParser to parse any nested
            // PhraseQueries with different
            // set of syntax restrictions (i.e. all fields must be same)
            isPass2ResolvingPhrases = true;
            try
            {
                using (IEnumerator<ComplexPhraseQuery> enumerator = complexPhrases.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        currentPhraseQuery = enumerator.Current;
                        currentPhraseQuery.ParsePhraseElements(this);
                    }
                }
            }
            finally
            {
                isPass2ResolvingPhrases = false;
            }
            return q;
        }
    
        // There is No "getTermQuery throws ParseException" method to override so
        // unfortunately need
        // to throw a runtime exception here if a term for another field is embedded
        // in phrase query
        protected override Query NewTermQuery(Term term)
        {
            if (isPass2ResolvingPhrases)
            {
                try
                {
                    CheckPhraseClauseIsForSameField(term.Field);
                }
                catch (ParseException pe)
                {
                    throw new SystemException("Error parsing complex phrase", pe);
                }
            }
            return base.NewTermQuery(term);
        }
    
        // Helper method used to report on any clauses that appear in query syntax
        private void CheckPhraseClauseIsForSameField(String field)
        {
            if (!field.Equals(currentPhraseQuery.Field))
            {
                throw new ParseException("Cannot have clause for field \"" + field
                    + "\" nested in phrase " + " for field \"" + currentPhraseQuery.Field
                    + "\"");
            }
        }
    
        protected override Query GetWildcardQuery(String field, String termStr)
        {
            if (isPass2ResolvingPhrases)
            {
                CheckPhraseClauseIsForSameField(field);
            }
            return base.GetWildcardQuery(field, termStr);
        }
    
        protected override Query GetRangeQuery(String field, String part1, String part2, Boolean inclusive)
        {
            if (isPass2ResolvingPhrases)
            {
                CheckPhraseClauseIsForSameField(field);
            }
            return base.GetRangeQuery(field, part1, part2, inclusive);
        }
    
        protected override Query NewRangeQuery(String field, String part1, String part2,
            Boolean inclusive)
        {
            if (isPass2ResolvingPhrases)
            {
                // Must use old-style RangeQuery in order to produce a BooleanQuery
                // that can be turned into SpanOr clause
                TermRangeQuery rangeQuery = new TermRangeQuery(field, part1, part2, inclusive, inclusive, RangeCollator);
                rangeQuery.RewriteMethod = MultiTermQuery.SCORING_BOOLEAN_QUERY_REWRITE;
                return rangeQuery;
            }
            return base.NewRangeQuery(field, part1, part2, inclusive);
        }
    
    
        protected Query GetFuzzyQuery(String field, String termStr, float minSimilarity)
        {
            if (isPass2ResolvingPhrases)
            {
                CheckPhraseClauseIsForSameField(field);
            }
            return base.GetFuzzyQuery(field, termStr, minSimilarity);
        }
    
        /*
         * Used to handle the query content in between quotes and produced Span-based
         * interpretations of the clauses.
         */
        class ComplexPhraseQuery : Query
        {
    
            public string Field { get; set; }
    
            public string PhrasedQueryStringContents { get; set; }
    
            public int SlopFactor { get; set; }
    
            private Query Contents;
    
            public ComplexPhraseQuery(string Field, string PhrasedQueryStringContents, int SlopFactor)
                : base()
            {
                this.Field = Field;
                this.PhrasedQueryStringContents = PhrasedQueryStringContents;
                this.SlopFactor = SlopFactor;
            }
    
            // Called by ComplexPhraseQueryParser for each phrase after the main
            // parse
            // thread is through
            public void ParsePhraseElements(QueryParser qp)
            {
                // TODO ensure that field-sensitivity is preserved ie the query
                // string below is parsed as
                // field+":("+phrasedQueryStringContents+")"
                // but this will need code in rewrite to unwrap the first layer of
                // boolean query
                Contents = qp.Parse(PhrasedQueryStringContents);
            }
    
            public override Query Rewrite(IndexReader reader)
            {
                // ArrayList spanClauses = new ArrayList();
                if (Contents is TermQuery)
                {
                    return Contents;
                }
    
                // Build a sequence of Span clauses arranged in a SpanNear - child
                // clauses can be complex
                // Booleans e.g. nots and ors etc
                int numNegatives = 0;
                if (!(Contents is BooleanQuery))
                {
                    throw new ArgumentException("Unknown query type \""
                        + Contents.GetType()
                        + "\" found in phrase query string \"" + PhrasedQueryStringContents
                        + "\"");
                }
                BooleanQuery bq = (BooleanQuery)Contents;
                BooleanClause[] bclauses = bq.GetClauses();
                SpanQuery[] allSpanClauses = new SpanQuery[bclauses.Length];
                // For all clauses e.g. one* two~
                for (int i = 0; i < bclauses.Length; i++)
                {
                    // HashSet bclauseterms=new HashSet();
                    Query qc = bclauses[i].Query;
                    // Rewrite this clause e.g one* becomes (one OR onerous)
                    qc = qc.Rewrite(reader);
                    if (bclauses[i].Occur.Equals(Occur.MUST_NOT))
                    {
                        numNegatives++;
                    }
    
                    if (qc is BooleanQuery)
                    {
                        List<SpanQuery> sc = new List<SpanQuery>();
                        AddComplexPhraseClause(sc, (BooleanQuery)qc);
                        if (sc.Count > 0)
                        {
                            allSpanClauses[i] = sc[0];
                        }
                        else
                        {
                            // Insert fake term e.g. phrase query was for "Fred Smithe*" and
                            // there were no "Smithe*" terms - need to
                            // prevent match on just "Fred".
                            allSpanClauses[i] = new SpanTermQuery(new Term(Field,
                                "Dummy clause because no terms found - must match nothing"));
                        }
                    }
                    else
                    {
                        if (qc is TermQuery)
                        {
                            TermQuery tq = (TermQuery)qc;
                            allSpanClauses[i] = new SpanTermQuery(tq.Term);
                        }
                        else
                        {
                            throw new ArgumentException("Unknown query type \""
                                + qc.GetType()
                                + "\" found in phrase query string \""
                                + PhrasedQueryStringContents + "\"");
                        }
    
                    }
                }
                if (numNegatives == 0)
                {
                    // The simple case - no negative elements in phrase
                    return new SpanNearQuery(allSpanClauses, SlopFactor, true);
                }
                // Complex case - we have mixed positives and negatives in the
                // sequence.
                // Need to return a SpanNotQuery
                List<SpanQuery> positiveClauses = new List<SpanQuery>();
                for (int j = 0; j < allSpanClauses.Length; j++)
                {
                    if (!bclauses[j].Occur.Equals(Occur.MUST_NOT))
                    {
                        positiveClauses.Add(allSpanClauses[j]);
                    }
                }
    
                //SpanQuery[] includeClauses = positiveClauses.ToArray(new SpanQuery[positiveClauses.Count]);
                SpanQuery[] includeClauses = positiveClauses.ToArray();
    
                SpanQuery include = null;
                if (includeClauses.Length == 1)
                {
                    include = includeClauses[0]; // only one positive clause
                }
                else
                {
                    // need to increase slop factor based on gaps introduced by
                    // negatives
                    include = new SpanNearQuery(includeClauses, SlopFactor + numNegatives,
                        true);
                }
                // Use sequence of positive and negative values as the exclude.
                SpanNearQuery exclude = new SpanNearQuery(allSpanClauses, SlopFactor,
                    true);
                SpanNotQuery snot = new SpanNotQuery(include, exclude);
                return snot;
            }
    
            private void AddComplexPhraseClause(List<SpanQuery> spanClauses, BooleanQuery qc)
            {
                List<SpanQuery> ors = new List<SpanQuery>();
                List<SpanQuery> nots = new List<SpanQuery>();
                BooleanClause[] bclauses = qc.GetClauses();
    
                // For all clauses e.g. one* two~
                for (int i = 0; i < bclauses.Length; i++)
                {
                    Query childQuery = bclauses[i].Query;
    
                    // select the list to which we will add these options
                    List<SpanQuery> chosenList = ors;
                    if (bclauses[i].Occur == Occur.MUST_NOT)
                    {
                        chosenList = nots;
                    }
    
                    if (childQuery is TermQuery)
                    {
                        TermQuery tq = (TermQuery)childQuery;
                        SpanTermQuery stq = new SpanTermQuery(tq.Term);
                        stq.Boost = tq.Boost;
                        chosenList.Add(stq);
                    }
                    else if (childQuery is BooleanQuery)
                    {
                        BooleanQuery cbq = (BooleanQuery)childQuery;
                        AddComplexPhraseClause(chosenList, cbq);
                    }
                    else
                    {
                        // TODO alternatively could call extract terms here?
                        throw new ArgumentException("Unknown query type:"
                            + childQuery.GetType());
                    }
                }
                if (ors.Count == 0)
                {
                    return;
                }
                SpanOrQuery soq = new SpanOrQuery(ors.ToArray());
                if (nots.Count == 0)
                {
                    spanClauses.Add(soq);
                }
                else
                {
                    SpanOrQuery snqs = new SpanOrQuery(nots.ToArray());
                    SpanNotQuery snq = new SpanNotQuery(soq, snqs);
                    spanClauses.Add(snq);
                }
            }
    
    
            public override String ToString(String field)
            {
                return "\"" + PhrasedQueryStringContents + "\"";
            }
    
    
            public override int GetHashCode()
            {
                const int prime = 31;
                int result = 1;
                result = prime * result + ((Field == null) ? 0 : Field.GetHashCode());
                result = prime
                    * result
                    + ((PhrasedQueryStringContents == null) ? 0
                        : PhrasedQueryStringContents.GetHashCode());
                result = prime * result + SlopFactor;
                return result;
            }
    
            public override Boolean Equals(Object obj)
            {
                if (this == obj)
                    return true;
                if (obj == null)
                    return false;
                if (GetType() != obj.GetType())
                    return false;
                ComplexPhraseQuery other = (ComplexPhraseQuery)obj;
                if (Field == null)
                {
                    if (other.Field != null)
                        return false;
                }
                else if (!Field.Equals(other.Field))
                    return false;
                if (PhrasedQueryStringContents == null)
                {
                    if (other.PhrasedQueryStringContents != null)
                        return false;
                }
                else if (!PhrasedQueryStringContents
                  .Equals(other.PhrasedQueryStringContents))
                    return false;
                if (SlopFactor != other.SlopFactor)
                    return false;
                return true;
            }
        }
    }
 
