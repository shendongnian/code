    object missing = System.Reflection.Missing.Value; 
    var document = application.ActiveDocument;
    Word.WdStatistic stat = Word.WdStatistic.wdStatisticPages; 
    int num =  aDoc.ComputeStatistics(stat, ref missing);    // Get number of pages
    
    for(int i=0; i<num; i++)
    {
        document.ActiveWindow.Selection           // Go to page "i"
                .GoTo(WdGoToItem.wdGoToPage, missing, missing, i.ToString());
        document.ActiveWindow.Selection           // Select whole page
                .GoTo(WdGoToItem.wdGoToBookmark, missing, missing, "\\page");
        document.ActiveWindow.Selection.Copy();   // Copy to clipboard
    
        // Do whatever you want with the selection
    }
