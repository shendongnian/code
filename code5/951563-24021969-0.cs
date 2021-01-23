    public DataTable buildEmployeeDataTable(DataSet ds)
        {
            
            DataTable personIdentity = ds.Tables["PersonIdentity"];
            DataTable person = ds.Tables["Person"]; ;
            
            var query = (
                from pi in personIdentity.AsEnumerable()
                join p in person.AsEnumerable() 
                    on personIdentity.Rows.IndexOf(pi) equals
                    person.Rows.IndexOf(p)
                select new
                {
                    PersonKey = pi.Field<string>("PersonKey"),
                    PersonNumber = p.Field<string>("PersonNumber"),
                    FullName = p.Field<string>("FullName")
                }).ToList();
              
            DataTable dataTable = ConvertToDataTable(query);
            return dataTable;
        }
