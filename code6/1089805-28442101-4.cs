    List<dto> dto = (from t in entities.tbl
                     where
                     filteredSearchTerms.Any(v => t.Description.Contains(v)) 
                     select new dto
                     {
                       description = t.Description
                     }).AsEnumerable()
                       .Where(obj => filteredSearchTerms.Any(v => System.Text.RegularExpressions.Regex.IsMatch(obj, string.Format(@"\b{0}\b", v))))
                       .Take(10).ToList();
