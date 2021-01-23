    class MyClass {
       public ObjectId Id { get; set; }
       public ObjectId UserId { get; set; }
       public string Description { get; set; }
       // ...
    }
    var coll = mongoDb.GetCollection<MyClass>("MyClass");
    var result = coll.Find(Query<MyClass>.EQ(p => p.UserId == someId));
   
    // result is now a MongoCursor<MyClass>
