    var collection = test.GetCollection<STObject>("collectionName");
    var sto = collection.FindOne(Query.EQ("_id", new ObjectId("xxxxx")));
    var businessList = sto.BusinessList.FirstOrDefault();
    var bsub = businessList.SubBuiness.OfType<BsubBusiness>().FirstOrDefault();
    var b = bsub.B; // returns bbbbb
