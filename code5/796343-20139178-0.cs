    string folder = "/images/%"; // this will be populated from WebPart via a property
    List<string> paths = new List<string>();
    TreeProvider treeProvider = new TreeProvider();
    TreeNodeDataSet imageNodes = treeProvider.SelectNodes(CMSContext.CurrentSiteName, folder, CMSContext.PreferredCultureCode, false);
    foreach (TreeNode imageNode in imageNodes)
    {
        string path = ValidationHelper.GetString(imageNode["YourImageColumnName"], "");
        if (path.Length > 0)
        {
            paths.Add(path);
        }
    }
...
