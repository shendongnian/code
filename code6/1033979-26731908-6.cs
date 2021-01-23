    Microsoft.Office.Tools.Word.Document vstoDoc = Globals.Factory.GetVstoObject(this.Application.ActiveDocument);
    ApplicationEvents2_DocumentBeforeSaveEventHandler handler = vstoDoc.BeforeSave;
    for (int i = 0; i < handler.GetInvocationList().Length; i++)
    {
        try
        {
            vstoDoc.BeforeSave -= new Microsoft.Office.Tools.Word.SaveEventHandler(ThisDocument_BeforeSave);
        }
        catch
        {
        } //may raise exception if a handler is not attached.
    }
