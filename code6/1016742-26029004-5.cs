    object fileName = (object)@"C:\test.docx";
    object oMissing = System.Reflection.Missing.Value;
    Microsoft.Office.Interop.Word.Application oWord = new Application();
    oWord.Documents.Open(ref fileName);
    object gotoPage1 = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage;
    object gotoNext1 = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;
    object gotoCount1 = null;
    object gotoName1 = 1;
    oWord.Selection.GoTo(ref gotoPage1, ref gotoNext1, ref gotoCount1, ref gotoName1);
    //Insert a blank page  
    oWord.Selection.InsertNewPage();
    object what = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage;
    object which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToAbsolute;
    object count = 2; //change this number to specify the start of a different page
    oWord.Selection.GoTo(ref what, ref which, ref count, ref oMissing);
    Object beginPageTwo = oWord.Selection.Range.Start; // This gets the start of the page specified by count object
    Microsoft.Office.Interop.Word.Range rangeForTOC = oWord.ActiveDocument.Range(ref beginPageTwo);
    oWord.ActiveDocument.TablesOfContents.Add(rangeForTOC);
