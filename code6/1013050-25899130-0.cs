     private T SelectRowById<T, TId>(TId id) where T : class
        {
            using (var dc = new DBDataContext())
            {
                // Get the table by the type passed in
                var table = dc.GetTable<T>();
                // Get the metamodel mappings (database to domain objects)
                MetaModel modelMap = table.Context.Mapping;
                // Get the data members for this type
                ReadOnlyCollection<MetaDataMember> dataMembers = 
      modelMap.GetMetaType(typeof(T)).DataMembers;
                // Find the primary key field name by checking for IsPrimaryKey
                string pk = (dataMembers.Single(m => m.IsPrimaryKey)).Name;
    
                // Return a single object where the id argument matches the primary key 
     field value
                return table.SingleOrDefault(delegate(T t)
                {
                    var memberId =
                       (TId)t.GetType().GetProperty(pk).GetValue(t, null);
                    return memberId == id;
                });
            }
        }
