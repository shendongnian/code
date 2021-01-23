    protected void rptPendingCourses_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem listItem = (ListViewDataItem)e.Item;
            DataRowView dataItem = (DataRowView)listItem.DataItem;
            if (Convert.ToBoolean(dataItem.Row["RatingsEnabled"]))
            {
                Rating rating = (Rating)e.Item.FindControl("courseRating");
                rating.Visible = true;
                rating.CurrentRating = Convert.ToInt32(dataItem.Row["AverageRating"]);
            }
        }
    }
