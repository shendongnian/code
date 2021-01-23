    public string[] GetPagesDoc(object Path)
        {
            List<string> Pages = new List<string>();
            // Get application object
            Microsoft.Office.Interop.Word.Application WordApplication = new Microsoft.Office.Interop.Word.Application();
            // Get document object
            object Miss = System.Reflection.Missing.Value;
            object ReadOnly = false;
            object Visible = false;
            Document Doc = WordApplication.Documents.Open(ref Path, ref Miss, ref ReadOnly, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Miss, ref Visible, ref Miss, ref Miss, ref Miss, ref Miss);
            
            // Get pages count
            Microsoft.Office.Interop.Word.WdStatistic PagesCountStat = Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages;
            int PagesCount = Doc.ComputeStatistics(PagesCountStat, ref Miss);
            //Get pages
            object What = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage;
            object Which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;
            object Start;
            object End;
            object CurrentPageNumber;
            object NextPageNumber;
            for (int Index = 1; Index < PagesCount + 1; Index++)
            {
                CurrentPageNumber = (Convert.ToInt32(Index.ToString()));
                NextPageNumber = (Convert.ToInt32((Index+1).ToString()));
                // Get start position of current page
                Start = WordApplication.Selection.GoTo(ref What, ref Which, ref CurrentPageNumber, ref Miss).Start;
                // Get end position of current page                                
                End = WordApplication.Selection.GoTo(ref What, ref Which, ref NextPageNumber, ref Miss).End;
                
                // Get text
                if (Convert.ToInt32(Start.ToString()) != Convert.ToInt32(End.ToString()))
                    Pages.Add(Doc.Range(ref Start, ref End).Text);
                else
                    Pages.Add(Doc.Range(ref Start).Text);
            }
                return Pages.ToArray<string>();
        }
