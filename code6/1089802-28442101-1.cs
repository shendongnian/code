    string[] seperator = { " " };
    string[] filteredSearchTerms = searchTerm.Split(seperator, StringSplitOptions.None);
    
       var entities = new Entity();
       List<dto> dto = (from t in entities.tbl
                         where
                         filteredSearchTerms.Any(v => System.Text.RegularExpressions.Regex.IsMatch(t, string.Format(@"\b{0}\b", v))) 
                         select new dto
                         {
                           description = t.Description
                         }).Take(10).ToList();
