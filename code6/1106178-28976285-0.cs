    public ObjectId Save(entity)
    {
       WriteConcernResult result = Collection.Save(entity);
       return result.Upserted
    }
