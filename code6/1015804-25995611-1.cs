    using MongoDB.Driver.Builders; // Make Fields class accessible
    var fields = "secondary.amount";
    foreach (var document in collection.FindAllAs<BsonDocument>()
        .SetFields(Fields.Include(fields).Exclude("_id"))
    {
        foreach (string name in document.Names)
        {
            BsonElement element = document.GetElement(name);                  
            Console.WriteLine("{0}", element.Value);
        }
    }
