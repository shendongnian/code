    public static List<DocumentCompare> CompareDocuments(WordprocessingDocument doc1, WordprocessingDocument doc2)
        {
            XDocument xDoc1 = doc1.MainDocumentPart.GetXDocument();
            XDocument xDoc2 = doc2.MainDocumentPart.GetXDocument();
            // these queries return the elements that contain text in the word documents
            var doc1Elements = xDoc1
                .Descendants()
                .Where(e => e.Name != W.commentRangeStart
                            && e.Name != W.commentRangeEnd
                            && e.Name != W.proofErr
                            && !e.Ancestors(W.p).Any());
            var doc2Elements = xDoc2
                .Descendants()
                .Where(e => e.Name != W.commentRangeStart
                            && e.Name != W.commentRangeEnd
                            && e.Name != W.proofErr
                            && !e.Ancestors(W.p).Any());
            List<DocumentCompare> differences = new List<DocumentCompare>();
            IEnumerable<bool> correspondingElementEquivalency = doc1Elements.Zip(doc2Elements, (e1, e2) =>
            {
                bool difference = false;
                if (e1.Name != e2.Name)
                {
                    return false;
                }
                if (e1.Name == W.p && e2.Name == W.p)
                {
                    // e1.Name == W.p && 
                    if ((GetParagraphText(e1) != GetParagraphText(e2)))
                    {
                        // there is a difference between the documents
                        difference = true;
                    }
                    // record lines
                    differences.Add(new DocumentCompare() { Document1Text = e1.Value, Document2Text = e2.Value, Difference = difference });
                }
                return true;
            });
            // determine if the documents are equivalent
            bool test = correspondingElementEquivalency.Any(e => e != true);
            var testDoc1 = new List<string>();
            var testDoc2 = new List<string>();
            foreach (var i1 in doc1Elements)
            {
                if (i1.Name == W.p)
                    testDoc1.Add(i1.Value);
            }
            foreach (var i2 in doc2Elements)
            {
                if (i2.Name == W.p)
                    testDoc2.Add(i2.Value);
            }
            // get document sizes
            var largerDoc = testDoc1.Count() > testDoc2.Count() && testDoc1.Count() != testDoc2.Count() ? testDoc1 : testDoc2;
            var smallerDocCount = doc1Elements.Count() < testDoc2.Count() && testDoc1.Count() != testDoc2.Count() ? testDoc1.Count() : testDoc2.Count();
            var doc1Larger = testDoc1.Count() > testDoc2.Count() && testDoc1.Count() != testDoc2.Count() ? true : false;
            var doc1Arr = testDoc1.ToArray();
            var doc2Arr = testDoc2.ToArray();
            // add in the remaining text for the larger document
            for (var i = smallerDocCount; i < largerDoc.Count(); i++)
            {
                // if doc1 is larger, add doc 1 and null for doc 2
                if (doc1Larger)
                {
                    Console.WriteLine("doc1 Text: {0}", doc1Arr[i]);
                    differences.Add(new DocumentCompare() { Document1Text = doc1Arr[i], Document2Text = "", Difference = true });
                }
                else if(!doc1Larger) {
                    Console.WriteLine("doc2 Text: {0}", doc2Arr[i]);
                    differences.Add(new DocumentCompare() { Document1Text = "", Document2Text = doc2Arr[i], Difference = true });
                }
            }
            return differences;
        }
