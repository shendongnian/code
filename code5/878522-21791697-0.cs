    protected void ListOfAssignments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Button delButton = e.Item.FindControl("RemoveAssignment") as Button;
            delButton.CommandArgument = //set to the value of AssignmentID
            //rest of your code
        }
    }
