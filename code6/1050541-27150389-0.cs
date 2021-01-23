    public void batchInsert(Question Model)
    {
     _collection = _db.GetCollection<Question>("Question");
     BsonDocument[] batch = new BsonDocument[Model.QuestionList.Count];
    
     int count = 0;
    
     foreach (Question question in Model.QuestionList)
     {
         BsonDocument rulesBsonDoc = new BsonDocument();
    
         foreach (KeyValuePair<string, VariableDetails> qTemp in question.Rules)
         {
             string variableName = qTemp.Key;
             VariableDetails variableDetails = qTemp.Value;
             string variableType = variableDetails.variableType;
             string min = variableDetails.min;
             string max = variableDetails.max;
    
             BsonDocument childBsonDoc = new BsonDocument();
             childBsonDoc.Add(new BsonElement("variableType", variableType));
             childBsonDoc.Add(new BsonElement("min", min));
             childBsonDoc.Add(new BsonElement("max", max));    
    
             rulesBsonDoc.Add(new BsonElement(variableName, childBsonDoc));
          }
    
          BsonDocument bsonDoc = new BsonDocument();
          bsonDoc.Add(new BsonElement("Name", question.Name));
          bsonDoc.Add(new BsonElement("Rules", rulesBsonDoc));
          batch[count] = bsonDoc;
          count++;
      }
      _collection.InsertBatch(batch);
    }
