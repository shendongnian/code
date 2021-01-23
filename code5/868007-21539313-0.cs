    public object Get(EMEM request)
    {
        var dbFactory = new OrmLiteConnectionFactory(Global.connString, SqlServerDialect.Provider);
        using (IDbConnection db = dbFactory.OpenDbConnection())
        {
            List<EMEM> results = null;
            List<EMEMResponse> response = new List<EMEMResponse>();
            if (request.Equipment != null)
            {
                results = db.Select<EMEM>(p => p.Where(ev => ev.Equipment == request.Equipment && ev.EMCo == 1));  // EMCo = 1 has been added as Kent only wants to see this company
            }
            else
            {
                results = db.Select<EMEM>(p => p.Where(ev => ev.EMCo == 1)); // EMCo = 1 has been added as Kent only wants to see this company
            }
    
            foreach (var item in results)
            {
                var test1 = new EMEMResponse().PopulateWith(item);
                test1.extraField1 = "extra";
                response.Add(test1);
            }
    
            return response;
        }
    }
