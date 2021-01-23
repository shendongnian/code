    IDisposable disposable = This.Selection.DeclareChangeBlock();
    using (disposable)
    {
        ...
        // SETTING THE CULTURE ->
        This.SetSelectedText(str, InputLanguageManager.Current.CurrentInputLanguage);
        ...
    }
