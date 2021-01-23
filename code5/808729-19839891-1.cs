    protected void viewHoursButton_OnClick(object sender, EventArgs e)
    {
        var viewHoursButton = (Button)sender;
        var viewHoursPopup = viewHoursButton.Parent.FindControl("viewHoursPopup");
        var viewHoursGridView = viewHoursButton.Parent.FindControl("viewHoursGridView");
        if (viewHoursPopup != null && viewHoursGriView != null)
        {
             viewHoursPopup.Show();
            viewHoursGridView.DataBind();
        }
    }
