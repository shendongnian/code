    public ActionResult INVAssets()
    {
      var assetList=new List<Tracker.Models.INV_Assets>();
            
      // Ex : manually adding one record. replace with your actual code to load data
      // to do : Add item to the list now
      assetList.Add(new INV_Assets { Name ="Test"});
    
      return View(assetList);     
    }
