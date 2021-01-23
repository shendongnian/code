    var subjects = 
        from r in dtFiles.AsEnumerable()
        group r by r.Field<int>("SubjectID") into g
        select new {
           ID = g.Key,
           Students = String.Join(", ", g.Select(r => r.Field<string>("StudentName"))
        };
