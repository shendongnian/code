    protected void Page_Load(object sender, EventArgs e)
    {
        var updatePanelControlIdThatCausedPostBack = String.Empty;
        var scriptManager = ScriptManager.GetCurrent(Page);
        
        if (scriptManager != null)
        {
            var smUniqueId = scriptManager.UniqueID;
            var smFieldValue = Request.Form[smUniqueId];
            if (!String.IsNullOrEmpty(smFieldValue) && smFieldValue.Contains("|"))
            {
                updatePanelControlIdThatCausedPostBack = smFieldValue.Split('|')[1];
            }
        }
        if (!String.IsNullOrEmpty(updatePanelControlIdThatCausedPostBack))
        {
            // Do something with control ID value that caused UpdatePanel postback here
        }
    }
