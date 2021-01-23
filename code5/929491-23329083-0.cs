    var request = new Request();
    var requestData = Session["request"] as SomeRequestDataModel;
    request.Property1 = requestData.Property1;
    request.Property2 = requestData.Property2;
    // etc., just copy the properties
    long val;
    var regionIDs = Session["regions"] as IEnumerable<string>;
    foreach (var item in regionIDs)
    {
        val = Convert.ToInt64(item);
        request.Regions.Add(cxt.Regions.Single(r => r.Id == val)); // or .Find(val)
    }
    var tagIDs = Session["tags"] as IEnumerable<string>;
    foreach (var item in tagIDs)
    {
        val = Convert.ToInt64(item);
        request.Regions.Add(cxt.Tags.Single(r => r.Id == val)); // or .Find(val)
    }
    cxt.Request.Add(request);
    cxt.SaveChanges();
