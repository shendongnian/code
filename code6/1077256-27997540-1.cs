    public void addSubDocument(SubDocumentModeloModel)
    {
        _MainDoc = _db.GetCollection<MainDocumentModel>("MainDoc");
        BsonDocument subDocument = new BsonDocument
        {
           {"_id", ObjectId.GenerateNewId()},//Previously it was {"Id", ObjectId.GenerateNewId().ToString()}
           {"Type", oModel.Name}
        };
    
        _query = Query<MainDocumentModel>.Where(e => e.Id == oModel.MainDocId);
        _updateBuilder = Update.Push("SubDocsList", subDocument);
        _MainDoc.Update(_query, _updateBuilder);
    }
