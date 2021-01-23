    activeWindow.ActivePane.View.Type = WdViewType.wdPrintView;
    activeWindow.ActivePane.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
                    
    //Check for blank headers
    activeWindow.ActivePane.Selection.WholeStory();
    var text = activeWindow.ActivePane.Selection.Text;
    if (!string.IsNullOrEmpty(text) && text.Equals("\r"))
    {
        activeWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
        continue;
    }
    // Get the full range of the header. This call causes my problem.
    Range headerRange = header.Range;
