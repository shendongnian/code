    var matchingIds = collection.FindAllAs<BsonDocument>
        .SetFields("_id", "Hash")
        .AsEnumerable() // force client side evaluation of the rest of the query
        .Where(x => ImageHash.Similarity(x["Hash"].AsByteArray, hash) > 50))
        .Select(x => x["_id"]);
    var query = Query.In("_id", matchingIds);
    var matchingImages = collection.Find(query);
    foreach (var image in matchingImages)
    {
        // process matching image
    }
