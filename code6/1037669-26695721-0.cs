    private void TopicsPage_ItemClick(object sender, ItemClickEventArgs e)
    {
        GridView gv = sender as GridView;
        index = gv.Items.IndexOf(e.ClickedItem);   // don't re cast it as anything; just past it
    }
