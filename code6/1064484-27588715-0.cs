    public partial class MyDbContext 
    {
        public override int SaveChanges()
        {
            // Other custom logic          
            ReplaceIDs();          
        }
              
        /// <summary>
        /// Replaces IDs with calculated values when saving
        /// </summary>
        private void ReplaceIDs()
        {
            Debug.Print("**************************************************************");
            this.ObjectContext.DetectChanges();
            foreach (var dbEntityEntry in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                Type t =  GetEntityType(dbEntityEntry.Entity);
                string baseTypeName = t.Name;
                // Get the entity key name
                var keyName = this.ObjectContext.MetadataWorkspace
                                .GetEntityContainer(this.ObjectContext.DefaultContainerName, DataSpace.CSpace)
                                .BaseEntitySets
                                .First(x => x.ElementType.Name.Equals(baseTypeName))
                                .ElementType
                                .KeyMembers
                                .Select(key => key.Name)
                                .FirstOrDefault();
                                
                string keyValue = null;  
                if (keyName!=null)
                {
                    keyValue = dbEntityEntry.CurrentValues[keyName]; 
                }
                string newKey = null;
                
                //Custom logic for ID replacement
                if (t.Name.Equals("MyTable") && keyValue!= null)
                {
                    string addedName = dbEntityEntry.CurrentValues["Name"];
                    int keyValueNumber;  
                    if (keyValue.HasValue && Int32.TryParse(keyValue, out keyValueNumber) && keyValueNumber <= 0) 
                    {
                        //Calculate shomehow the last value of your set of IDs
                        //I store last IDs for different sets in extra table, e.g. IDSets  
                        var q = from x in this.IDSets where x.Name.Equals(addedName) && x.TableName.Equals("MyTable")
                                select x.LastID;
                        var lastKey = q.FirstOrDefault();
                        if (lastKey == null) throw new Exception("..."); //Handle somehow missing ID set, create new etc.
                        int? newID = null;
                        if (lastKey.LastID  == null)
                           newID=1;
                        else
                           newID= lastKey.LastID;
                        newKey = string.Format("{0}-{1}",addedName,++newID);                        
                        lastKey.LastID = newID;  
                    }
                }
                //Key replacement
                if (newKey!=null)
                {
                    int originalKey = (int)dbEntityEntry.CurrentValues[keyName];
                    dbEntityEntry.CurrentValues[keyName] = newKey;
                    Debug.Print("{0},{1} = {2} : {3}", baseTypeName, addedKontext, newKey, newIDWithKontext);
                    //Refresh references
                    string keyNameHelper=String.Format("{0}_", keyName);
                    foreach (var e in ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged))
                    {
                        Type tfix = e.Entity.GetType().BaseType;
                        foreach (var pname in e.CurrentValues.PropertyNames)
                        {
                            if ((pname.Equals(keyName) || pname.StartsWith(keyNameHelper)))
                            {
                                object o = e.CurrentValues[pname];
                                if (o!=null && o.GetType() == typeof(Int32) && ((int)o) == originalKey)
                                {
                                    e.CurrentValues[pname] = newKey;
                                    Debug.Print("FIX: {0},{1} = {2} >> {3}",tfix.Name, pname, originalKey, newKey);
                                }
                            }
                        }
                    }
                }
            }
            this.ObjectContext.DetectChanges();
            Debug.Print("**************************************************************");
        }
        public static Type GetEntityType(object entity)
        {
            if (entity == null)
                return null;
            if (IsProxy(entity))
                return entity.GetType().BaseType;
            else
                return entity.GetType();
        }
