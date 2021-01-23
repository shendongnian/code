         public virtual List<columns> Getcollection()
        {
            string SQLQuery = "call MangerModule();";
            var objectContext = ((IObjectContextAdapter)db).ObjectContext;
            List<object> listobj = new List<object>();
            List<columns> data = objectContext.ExecuteStoreQuery<columns>(SQLQuery).AsQueryable().ToList();
            return data;
        }
