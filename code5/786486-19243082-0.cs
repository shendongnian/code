    private void itemGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        this.Frame.Navigate(typeof (BasicPage1),
            ((MyWebApi.MainPageHeadline) e.ClickedItem).ARTICLEID);
    }
