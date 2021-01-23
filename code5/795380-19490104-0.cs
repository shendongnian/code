        Dictionary<string, int> sortDictionary = new Dictionary<string, int>();
        sortDictionary.Add("P", 1);
        sortDictionary.Add("D", 2);
        sortDictionary.Add("I", 3);
        var q = from row in dtGroup.AsEnumerable()
                let type = sortDictionary[row.Field<string>("Name").Substring(4, 1)]
                orderby type, row.Field<DateTime?>("Date")
                select row;
        foreach (var r in q)
        {
            string x = r["Name"].ToString() + r["Date"].ToString();
        }
