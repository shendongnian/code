    string command = "Copy";
    bool flag= Globals.ThisAddIn.Application.CommandBars.GetEnabledMso(command);
    if (flag)
    {
        Globals.ThisAddIn.Application.ActiveDocument.CommandBars.ExecuteMso(command);
    }
