    YourListViewItemType item;
    private void ListView1_ItemMouseHover(Object sender, ListViewItemMouseHoverEventArgs e) {
        item = e.Item;
    }
    private void Page_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if(item == null) return;
        if(e.KeyCode == Keys.Return)
        {
            // Do something with highlighted item
        }
    }
