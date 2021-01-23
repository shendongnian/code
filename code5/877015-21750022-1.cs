    private static bool IsInPostback(Browser browser)
    {
        string function =
            "(  typeof(Sys) === undefined " +
            "|| Sys == undefined || Sys == 'undefined' || Sys==null " +
            "|| typeof(Sys.WebForms) === undefined " +
            "|| Sys.WebForms==null || Sys.WebForms==undefined|| Sys.WebForms=='undefined'" +
            "|| typeof(Sys.WebForms.PageRequestManager) === undefined) " +
            "|| Sys.WebForms.PageRequestManager==null || Sys.WebForms.PageRequestManager==undefined|| Sys.WebForms.PageRequestManager=='undefined'" +
            "? true " +
            ": Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();";
        string result = browser.EvalSafely(function);
        return Convert.ToBoolean(result) && (hdnRequestCompletedFlag.Value == '1');
    }
