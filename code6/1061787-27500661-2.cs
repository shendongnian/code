    private void BindMethods(IWebView _webView)
    {
        JSValue result = webControl.CreateGlobalJavascriptObject("app");
        if (result.IsObject)
        {
            JSObject appObject = result;
            appObject.Bind("openNotepad", openNotepad);
        }
    }
    private JSValue openNotepad(object obj, JavascriptMethodEventArgs jsMethodArgs)
    {
        Process.Start("notepad.exe");
        return null;
    }
