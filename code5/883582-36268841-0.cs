    private void webBrowser_LoadCompleted(object sender, NavigationEventArgs e)
    {
        documentEvents = (HTMLDocumentEvents2_Event)webBrowserChat.Document; // this will access the events properties as needed
        documentEvents.oncontextmenu += webBrowserChat_ContextMenuOpening;
    }
    private bool webBrowserChat_ContextMenuOpening(IHTMLEventObj pEvtObj)
    {
        return false; // ContextMenu wont open
        // return true;  ContextMenu will open
        // Here you can create your custom contextmenu or whatever you want
    }
