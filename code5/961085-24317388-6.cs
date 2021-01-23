        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdatePanel myUpdatePanel = Page.Master.Master.FindControl("ContentPlaceHolder_Footer").FindControl("UpdatePanel") as UpdatePanel;
            Label myLabel = Page.Master.Master.FindControl("ContentPlaceHolder_Footer").FindControl("DataFromPage") as Label;
            myLabel.Text = "this is a message from my content page";
            myUpdatePanel.Update(); //force the panel to get updated
        }
