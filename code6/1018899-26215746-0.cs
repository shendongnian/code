    MongoDatabase db = MdbServer.GetDatabase(strDbName);
                            MongoCollection<BsonDocument> collection = db.GetCollection(strCollectionName);                          
                            foreach (var document in collection.Find(query).SetFields(Fields.Include(includeFields).Exclude("_id")))
                            {
                                foreach (string name in document.Names)
                                {
                                    BsonElement element = document.GetElement(name);
                                    BsonValue value = document.GetElement(name).Value;
                                    bsonDoc.Add(element.Name, value);
                                }
                            }
