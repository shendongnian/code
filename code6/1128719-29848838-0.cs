    public static class UpdatePanelManager
    {
        private const string SessionName = "UpdatePanelRefresh";
        public static void RegisterToUpdate(System.Web.UI.UpdatePanel updatePanel)
        {
            updatePanel.Update();
            if (HttpContext.Current.Session[SessionName] == null)
            {
                HttpContext.Current.Session[SessionName] = new List<string>();
            }
            ((List<string>)HttpContext.Current.Session[SessionName]).Add(updatePanel.ClientID);
        }
        public static bool IsUpdating(System.Web.UI.UpdatePanel updatePanel)
        {
            bool output = false;
            // check if there is a JavaScript update request
            if (HttpContext.Current.Request["__EVENTTARGET"] == updatePanel.ClientID)
                output = true;
            // check if there is a code behind update request
            if (HttpContext.Current.Session[SessionName] != null
                && ((List<string>)HttpContext.Current.Session[SessionName]).Contains(updatePanel.ClientID))
            {
                output = true;
                ((List<string>)HttpContext.Current.Session[SessionName]).Remove(updatePanel.ClientID);
            }
            return output;
        }
        public static bool IsUpdatingOrPageLoading(System.Web.UI.UpdatePanel updatePanel, System.Web.UI.Page page)
        {
            bool output = false;
            if (!page.IsPostBack || IsUpdating(updatePanel))
                output = true;
            return output;
        }
    }
