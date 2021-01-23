    public void Loop_Opt()
    {
        Word.Application wordApp;
        Word.Document oDoc = null;
        wordApp = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
        oDoc = wordApp.ActiveDocument;
        Document DD = Globals.Factory.GetVstoObject(oDoc);
        PG.Maximum = oDoc.Bookmarks.Count;
        PG.Step = 1;
        PG.Value = 1;
        for (int i = 1; i <= oDoc.Bookmarks.Count; i++)
        {
           //loop operation//
           PG.PerformStep();
           Thread.Sleep(100);
           Application.DoEvents();
        }
      }
 
