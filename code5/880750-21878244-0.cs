    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
        
    }        
    void Application_DocumentChange()
    {
        if (this.Application.ActiveDocument.Comments.Count > 2 /* && code to check if its first document opening or changing documents */)
        {
            object unit = Word.WdUnits.wdColumn;
            object missing = Type.Missing;
                
            this.Application.ActiveDocument.Comments[3].Scope.Select();
            this.Application.Selection.StartOf(ref unit, ref missing);
        }
    }
