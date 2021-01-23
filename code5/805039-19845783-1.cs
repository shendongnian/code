    protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ViewState["closewindow"] != null)
                closewindow = (bool)ViewState["closewindow"];
            if (closewindow)
            {
                closewindow = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close_Window", "self.close();", true);
                ///System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Close_Window", "self.close();", true);
            }
        }
