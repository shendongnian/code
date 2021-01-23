    var query = (from r in dt.AsEnumerable()
                        where r.Field<string>("Code") == strCode                       
                        select (decimal.Parse(r.Field<string>("Amount").Replace("$", String.Empty).Replace(",", String.Empty)))).Sum();
    if (query == 0)
            {             
               a = "0";        
            }
            else
            {
                a = query.ToString();
            }
            return a;
