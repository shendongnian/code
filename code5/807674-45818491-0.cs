    public void SelectListItem(string selectedItem, string ListID, UITestControl parent)
        {
            HtmlList ListControl = new HtmlList(parent);
            ListControl.SearchProperties[HtmlList.PropertyNames.Id] = ListID;
            ListControl.SelectedItemsAsString = selectedItem;
        }
