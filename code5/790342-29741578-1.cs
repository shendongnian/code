    private void WebView_OnScriptNotify(object sender, NotifyEventArgs e)
    {
         if (e.Value.StartsWith("app"))
         {
             DoAction(e.Value);
             return;
         }
    }
