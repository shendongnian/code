        public void SaveRelationshipCodes(int id, RelationshipCodeLookup relCode)
        {
            if (relCode.AgentId == 0) relCode.AgentId = id;
            relCode.LastChangeDate = DateTime.Now;
            relCode.LastChangeId = Security.GetUserName(User);
            //Check to see if record exists and if not add it
            if (db.RelationshipCodeLookup.Find(id, relCode.RelCodeOrdinal) != null)
            {
                //Need to call .Find to get .CurrentValues method call to work
                RelationshipCodeLookup dbRelCode = db.RelationshipCodeLookup.Find(id, relCode.RelCodeOrdinal); 
                db.Entry(dbRelCode).CurrentValues.SetValues(relCode);
            }
            else
            {
                if(relCode.RelCodeOrdinal == 0) relCode.RelCodeOrdinal = FindOrdinal(relCode);
                db.RelationshipCodeLookup.Add(relCode);
            }
            db.SaveChanges();
        }
