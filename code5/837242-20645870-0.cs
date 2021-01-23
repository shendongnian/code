     public TableObject PerformQuery(MyObject obj) {
            if (obj == null) {return null;}
            // also pull this out of the LINQ logic.
            string objGuid = obj.Guid.ToString();
            return context.TableObjects.FirstOrDefault(tableObject => 
                string.Equals(objGuid, tableObject.Hash));
        }
