    MongoDB.Driver.MongoClient client = new MongoClient(connectionString);
    var server = client.GetServer();
    var db = server.GetDatabase("MyDbName");
    var collection=db.GetCollection<Car>("Veh_info");
    Car carById= collection.Find(Query<Car>.EQ(x=>x.Id,1));
    if(carById!=null)
      carById.Locs.Add(new Location(){loc="my new location name"});
    collection.Save(carById);
