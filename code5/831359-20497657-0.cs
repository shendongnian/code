    public PartialViewResult MyAction(string contentItem)
    {
        Item selectedItem;
        //retrieve sitecore item
        string layoutPath = selectedItem.Visualization.Layout.FilePath;
        return PartialView(layoutPath, modalContentItem);
    }
