    WinListItem uIContactcshtmlListItem = this.UIProgramManagerWindow.UIDesktopList.UIContactcshtmlListItem;
    
    WinText uIDragDropFilesHereText = this.UIMyApp.UIDragDropFilesHereWindow.UIDragDropFilesHereText;
    
    uIContactcshtmlListItem.SearchProperties.Remove(UITestControl.PropertyNames.Name);
    uIContactcshtmlListItem.SearchProperties.Add("Name", "ItemName" or variable);
    or uIContactcshtmlListItem.SearchProperties.Add("Name", "PartOfTheName", PropertyExpressionOperator.Contains);
    
    
    uIDragDropFilesHereText.EnsureClickable(new Point(84, 13));
    
    Mouse.StartDragging(uIContactcshtmlListItem, new Point(17, 35));
    Mouse.StopDragging(uIDragDropFilesHereText, new Point(84, 13));
