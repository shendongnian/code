    public void OnDocumentComplete(object pDisp, ref object URL)
    {
        if (pDisp != this.site) {
            // Ignore subframes
            return;
        }
        document = (HTMLDocument)webBrowser.Document;    
        document.body.style.backgroundColor = "red";
    } 
