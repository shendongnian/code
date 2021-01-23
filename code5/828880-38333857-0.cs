    //register clipboard change
                YourAppName.ClipboardUpdate += new EventHandler(ClipboardChanged);
    private void ClipboardChanged(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            //clipboard not empty and these are the formats I am only interested in
            if (iData.GetDataPresent(DataFormats.UnicodeText) || iData.GetDataPresent(DataFormats.Text) || iData.GetDataPresent(DataFormats.Html)) 
            { 
             //do work
            }
         }    
