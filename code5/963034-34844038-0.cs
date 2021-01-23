    //Connect and Query from MongoDB
    var db = client.GetDatabase("blog");
    var col = db.GetCollection<BsonDocument>("users");
    var result = await col.Find(new BsonDocument("Email",model.Email)).ToListAsync();
    //read first row from the result
    var user1 = result[0];
    result[0] would be say "{ "_id" : ObjectId("569c05da09f251fb0ee33f5f"), "Name" : "fKfKWCc", "Email" : "pujkvBFU@kQKeYnabk.com" }"
    // a user class with name and email
    User user = new User();
    // assign 
    User.Name = user1[1].ToString();      // user1[1] is "fKfKWCc"    
    User.Email = user1[2].ToString();      // user1[2] is "pujkvBFU@kQKeYnabk.com"
