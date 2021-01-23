    /// <summary>
    /// switch to the view given as string parameter
    /// </summary>
    /// <param name="screenUri"></param>
    private void NavigateToView(string screenUri)
    {
        // if there is no MainRegion then something is very wrong
        if (this.regionManager.Regions.ContainsRegionWithName(RegionName.MainRegion))
        {
            // see if this view is already loaded into the region
            var view = this.regionManager.Regions[RegionName.MainRegion].GetView(screenUri);
            if (view == null)
            {
                // if not then load it now
                switch (screenUri)
                {
                    case "DriverStatsView":
                        this.regionManager.Regions[RegionName.MainRegion].Add(this.container.Resolve<IDriverStatsViewModel>().View, screenUri);
                        break;
                    case "TeamStatsView":
                        this.regionManager.Regions[RegionName.MainRegion].Add(this.container.Resolve<ITeamStatsViewModel>().View, screenUri);
                        break;
                    case "EngineStatsView":
                        this.regionManager.Regions[RegionName.MainRegion].Add(this.container.Resolve<IEngineStatsViewModel>().View, screenUri);
                        break;
                    default:
                        throw new Exception(string.Format("Unknown screenUri: {0}", screenUri));
                }
                // and retrieve it into our view variable
                view = this.regionManager.Regions[RegionName.MainRegion].GetView(screenUri);
            }
            // make the view the active view
            this.regionManager.Regions[RegionName.MainRegion].Activate(view);
        }
    }
