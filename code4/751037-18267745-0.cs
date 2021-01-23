    public ActionResult JobsDistanceSorted()
    {            
        var model = from j in db.Jobs select j;
        foreach (var item in model)
        {
            item.PickupDistanceSort = ICN.CustomMethods.
                   GetDistance(34.180046081543, -118.309028625488,
                   item.PickupLatitude, item.PickupLongitude);
        }
        db.SaveChanges();
        model = model.OrderBy(s => s.PickupDistanceSort);
