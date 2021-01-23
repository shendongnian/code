    public void SelectListItem(int selectedIndex, string ListID, UITestControl parent)
        {
            HtmlList ListControl = new HtmlList(parent);
            ListControl.SearchProperties[HtmlList.PropertyNames.Id] = ListID;
            //Select the item as the specific index.
            HtmlListItem listItem = (HtmlListItem) ListControl.GetChildren()[selectedIndex];
            listItem.Select();            
        }
