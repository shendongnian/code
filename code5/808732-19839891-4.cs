    protected void viewHoursButton_OnClick(object sender, EventArgs e)
    {
        var viewHoursPopup = parentGridView.FindControl("viewHoursPopup")
            as WebControl;
        var viewHoursGridView = parentGridView.FindControl("viewHoursGridView");
        if (viewHoursPopup != null && viewHoursGriView != null)
        {
             viewHoursPopup.Show();
            viewHoursGridView.DataBind();
        }
    }
