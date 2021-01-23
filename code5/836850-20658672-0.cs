    public static byte[] MergeFilesAndAddBookmarks(Dictionary<PrintDocument, byte[]> sourceFiles)
            {
                using (var ms = new MemoryStream())
                {
                    using (var document = new Document())
                    {
                        using (var copy = new PdfCopy(document, ms))
                        {
                            //Order the files by chapternumber
                            var files = sourceFiles.GroupBy(f => f.Key.ChapterNumber);
    
                            document.Open();
                            var outlines = new List<Dictionary<string, object>>();
    
                            var pageIndex = 1; 
    
                            foreach (var chapterGroup in files)
                            {
                                var map = new Dictionary<string, object>();
                                outlines.Add(map);
                                map.Add("Title", chapterGroup.First().Key.ChapterName);
                                var kids = new List<Dictionary<string, object>>();
                                map.Add("Kids", kids);
                                
                                foreach (var sourceFile in chapterGroup)
                                {
                                    var reader = new PdfReader(sourceFile.Value);
    
                                    // add the pages
                                    var n = reader.NumberOfPages;
    
                                    for (var page = 0; page < n;)
                                    {
                                        if (page == 0)
                                        {
                                            var kid = new Dictionary<string, object>();
                                            kids.Add(kid);
                                            kid["Title"] = sourceFile.Key.Title;
                                            kid["Action"] = "GoTo";
                                            kid["Page"] = String.Format("{0} Fit", pageIndex); 
                                        }
                                        copy.AddPage(copy.GetImportedPage(reader, ++page));
                                    }
    
                                    pageIndex += n;
                                }
                            }
                            copy.Outlines = outlines;
                        }
                    }
                    return ms.ToArray();
                }
            }
    public class PrintDocument
    {
        public string Title { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
    }
