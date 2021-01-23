    protected void btnAdd_Click(object sender, EventArgs e)
        {
            var txtNotes = (System.Web.UI.HtmlControls.HtmlInputText)(((Button)sender).Parent).FindControl("txtNotes");
            var ddlStatusList = (DropDownList)(((Button)sender).Parent).FindControl("ddlStatusList");
        }
