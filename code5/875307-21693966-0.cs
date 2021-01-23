    List<Record> records = new Record<Record>();
    
    foreach (GridViewRow row in grid.Rows)
    {
       // below code need to be change with your grid controls and id names, and add validations for handle null values etc..
       string id2 = ((Label)row.FindControl("ID2Label")).Text;
       string Price = ((TextBox)row.FindControl("PricetextBox")).Text;
       records.Add(new Record(){ ID2 = int.Parse(id2), Price = int.Parse(Price)});       
    }
    
    var results = records.GroupBy(r=>r.ID2)
                        .Select(g=> new Record(){ ID2 = g.Key, Price = g.Sum(x=>x.Price)})
                        .ToList();
