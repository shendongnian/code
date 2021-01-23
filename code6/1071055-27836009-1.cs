    partial void LINQ_Query_PreprocessQuery(ref IQueryable<Availabilities> query)
        {
            query = query.Where(x=>x.Availability.Length==7);
            query = query.Where(x=>x.Availability.Substring(0,4) == "2013";
        }
