    var handler = new ApplicationEvents2_DocumentBeforeSaveEventHandler(Target); 
    
    for (int i = 0; i < handler.GetInvocationList().Length; i++)
    {
        try
        {
            vstoDoc.GetVstoObject().BeforeSave -= new Microsoft.Office.Tools.Word.SaveEventHandler((o, args) => { });
        }
        catch { } //may raise exception if a handler is not attached.
    }
    
    }
    
    private void Target(Document doc, ref bool saveAsUi, ref bool cancel)
    {
    throw new NotImplementedException();
    }
