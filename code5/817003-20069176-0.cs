    var list = new List<string>
                   {
                       "11-03-2013",
                       "11-03-2013",
                       "11-03-2013",
                       "11-04-2013",
                       "11-04-2013",
                       "11-04-2013"
                   };
    
    DateTime d;
    IEnumerable<string> valid = list.Select(s => DateTime.TryParse(s, out d) ? s : DateTime.Now.ToShortDateString());
