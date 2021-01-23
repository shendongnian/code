      var newresult = result.SelectMany(cntry => cntry.data.Select(d => new { id = cntry.countryid, name = cntry.countryname, year = d.year, value = d.value }))
                            .GroupBy(f => f.year)
                            .Select(g => new { year = g.Key, placeList = g.Select(p => new { p.id, p.value })});
      
      
      DataTable table = new DataTable();
      
      table.Columns.Add("Year");
      foreach(string name in  result.Select(x => x.countryid).Distinct())
        table.Columns.Add(name);
        
      foreach(var item in newresult)
      {
        DataRow nr = table.NewRow();
        
        nr["Year"] = item.year;
        
        foreach(var l in item.placeList)
          nr[l.id] = l.value;
          
        table.Rows.Add(nr);
      }
      
      table.Dump();
