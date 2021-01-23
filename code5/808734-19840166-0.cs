    protected void viewHoursButton_OnClick(object sender, EventArgs e)
    {
        var viewHoursPopup = parentGridView.FindControl("viewHoursPopup") as ModalPopupExtender;
        var viewHoursGridView = parentGridView.FindControl("viewHoursGridView") as GridView;
        if (viewHoursPopup != null && viewHoursGriView != null)
        {
            viewHoursPopup.Show();
            viewHoursGridView.DataBind();
        }
    }
