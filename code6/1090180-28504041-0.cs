    using System.Collections.Specialized;
    
    private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        Clipboard.Clear();
        SendKeys.Send("^C");
        
        StringCollection sc = Clipboard.GetFileDroplist();
        Clipboard.Clear();
        
        if(sc.Count == 0) // Meaning no files in the list were copied
        {
            if (e.KeyCode == Keys.Back)
            {
                //Do only if no selected items in WebBrowser 
                webBrowser1.GoBack(); 
            }
        }
    }
