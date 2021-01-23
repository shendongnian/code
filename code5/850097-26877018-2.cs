     private string getNewValueAsString(DbEntityEntry dbEntry, string tableName, string propertyName)
        {
            var fkVal = getForeignKeyValue(tableName, propertyName, dbEntry.CurrentValues.GetValue<object>(propertyName));
            return fkVal != null ? fkVal.ToString()
                                : (dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null
                                    : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString());
        }
        private object getForeignKeyValue(string tableName, string propertyName, object foreignKeyID)
        {
            // if this property is part of a foreign key, we need to instead look that up and store the value of the
            // foreign key
            // first get all the foreign keys in the system
            var workspace = ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace;
            var items = workspace.GetItems<AssociationType>(DataSpace.CSpace);
            if (items == null) return null;
            var fk = items.Where(a => a.IsForeignKey).ToList();
            // now we look into the FK attributes and find that the "To Role" is out current table, and the
            // "To Property" is out current property. The underscore is a bit of an assumption that the foreign
            // key name built by EF will be ENTITY_BLAH_BLAH
            var thisFk = fk.Where(x => x.ReferentialConstraints[0].ToRole.Name.StartsWith(tableName + "_"))
                .FirstOrDefault(x => x.ReferentialConstraints[0].ToProperties[0].Name == propertyName);
            // if fkname has no results, this is not a foreign key and we are done
            if (thisFk == null) return null;
            // Now that we know the foriegn key, we need to lookup the Name value in the other table
            // find the assembly
            var assembly = Assembly.GetCallingAssembly();
            // build the type for the foreign key entity
            // e.g. if the current entity is Task, and the property is StatusID, we are 
            // getting the "TaskStatus" type with reflection
            // "User" class is an object in the Models namespace - you could just hardcode the string if you want
            var foreignKeyType = assembly.GetType(typeof(User).Namespace + "." +
                      thisFk.ReferentialConstraints[0].FromRole.GetEntityType().Name);
            // get the DbSet, same as: "(new DBContext()).EntityName"
            var fkSet = Set(foreignKeyType);
            // and find the row in that table
            var fkItem = fkSet.Find(foreignKeyID);
            // find the first column marked with the "IsName" attribute, otherwise default to "Name"
            var nameColProperty = foreignKeyType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(IsNameAttribute), false).Any());
            string nameCol = "Name";
            if (nameColProperty != null) nameCol = nameColProperty.Name;
            var nameColProperty2 = fkItem.GetType().GetProperty(nameCol);
            if (nameColProperty2 == null) return null;
            // get the value
            var fkValue = nameColProperty2.GetValue(fkItem, null);
            // and now, my brain hurts
            return fkValue;
        }
