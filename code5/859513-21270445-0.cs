    public class MyImage
    {
     [BsonId]
     public ObjectId id {get;set;}    
     public string Hash {get;set;}
    }
    
    var results = imageCollection
     .AsQueryable(MyImage)
    .Where(x=>ImageHash.Similarity(x.Hash, hash) >= 50)
    .ToList();
