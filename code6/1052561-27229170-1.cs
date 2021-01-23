    public JsonResult GetInstPlacesTree()
    {
        InstallationPlaceModel ipm = new InstallationPlaceModel();
        var dataContext = ipm.getRootInstallationPlaces();
        var instPlaces = from ip in dataContext.installationPlaces
                            select new TreeViewItemModel 
                            {
                                id = ip.installationPlace.id,
                                Name = ip.installationPlace.mediumDescription,
                                Items = getChildInstallationPlacesRecursive(ip.installationPlace.id, ipm)
                            };
        return Json(instPlaces, JsonRequestBehavior.AllowGet);
    }
    public List<TreeViewItemModel> getChildInstallationPlacesRecursive(int id, InstallationPlaceModel ipm)
    {
        List<TreeViewItemModel> children = new List<TreeViewItemModel>();
            
        var gipo = ipm.getChildInstallationPlaces(id);
        foreach (wsInstallationPlace.installationPlaceOutput child in gipo.installationPlaces)
        {
            children.Add(new TreeViewItemModel
            {
                Text = child.installationPlace.mediumDescription,
                Id = child.installationPlace.id,
                Items = getChildInstallationPlacesRecursive(child.installationPlace.id, ipm)
            });
        }
        return children;
    }
