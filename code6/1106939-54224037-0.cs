        /// <summary>
        /// Reads each page of the word document into a string and returns the list of the page strings.
        /// </summary>
        public static IEnumerable<string> ReadPages(string filePath)
        {
            ICollection<string> pageStrings = new List<string>();
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Document doc = app.Documents.Open(filePath);
            long pageCount = doc.ComputeStatistics(Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages);
            int lastPageEnd = 0; // The document starts at 0.
            for ( long i = 0; i < pageCount; i++)
            {
                // The "range" of the page break. This actually is a range of 0 elements, both start and end are the 
                // location of the page break.
                Range pageBreakRange = app.Selection.GoToNext(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage);
                string currentPageText = doc.Range(lastPageEnd, pageBreakRange.End).Text;
                lastPageEnd = pageBreakRange.End;
                pageStrings.Add(currentPageText);
            }
            return pageStrings;
        }
