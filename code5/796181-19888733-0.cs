    var x = new Dictionary<int, int>();
                    int numpages = pdfRenderer.PdfDocument.PageCount;
                    for (int idx = 0; idx < numpages; idx++)
                    {
                        DocumentObject[] docObjects = pdfRenderer.DocumentRenderer.GetDocumentObjectsFromPage(idx + 1);
                        if (docObjects != null && docObjects.Length > 0)
                        {
                            Section section = docObjects[0].Section;
                            int sectionTag = -1;
                            if (section != null)
                                sectionTag = (int)section.Tag;
                            if (sectionTag >= 0)
                            {
                                // count a section only once
                                if (!x.ContainsKey(sectionTag))
                                    x.Add(sectionTag, idx + 1);
                            }
                        }
                    }
