    DTE dte = null;
    try
    {
    	dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.11.0");
    }
    catch
    {    
    	System.Diagnostics.Process.Start("devenv");
    	System.Threading.Thread.Sleep(2000);
    	try
    	{
    		dte = (DTE)Marshal.GetActiveObject("VisualStudio.DTE.11.0");
    	}
    	catch
    	{
            //cant do much nw, notify
    	}
    }
    SearchResult result = (SearchResult)listFiles.SelectedItem;
    dte.ExecuteCommand("File.OpenFile", result.FileName);
    System.Threading.Thread.Sleep(200);
    dte.ExecuteCommand("Edit.GoTo", labelLineNo.Text);
    dte.MainWindow.Activate();
    dte.ActiveDocument.Activate();
