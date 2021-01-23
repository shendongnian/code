    public ActionResult JobsDistanceSorted()
    {            
        var model = db.Jobs.ToList();
        foreach (var item in model)
        {
            item.PickupDistanceSort = ICN.CustomMethods.
                   GetDistance(34.180046081543, -118.309028625488,
                   item.PickupLatitude, item.PickupLongitude);
        }
        model = model.OrderBy(s => s.PickupDistanceSort);
