    void OpenApplicationPageAsPopup(){
    string strWebUrl = SPContext.Current.Web.Url;
    string strPageURL = strWebUrl + "/_layouts/MyLayoutFolder/MyPage.aspx";
    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), ClientID, "ExecuteOrDelayUntilScriptLoaded(openModelDialogPopup('" + strPageURL + "'), \"SP.js\");", true);
    }
