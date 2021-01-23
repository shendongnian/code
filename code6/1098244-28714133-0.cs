        const string sql = @"SELECT Name, Street FROM Contact";
        IEnumerable<dynamic> results = null;
        using (var cn = Connection)
        {
            results = cn.Query<dynamic>(sql);
        }
        foreach (var row in results)
        {
             var fields = row as IDictionary<string, object>;
             // do something with fields["Name"] and fields["Street"]
        }
