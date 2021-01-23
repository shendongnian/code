    .GroupBy(r => new { 
         Ingredients = r.Field<string>("Ingredients"), 
         BakerP = r.Field<string>("BakerP"),
         FlourP = r.Field<string>("FlourP"),
         BatchP = r.Field<string>("BatchP")
     })
    .Select(g =>
         {
             var row = dt.NewRow();
             row.ItemArray = new object[]
                {
                    g.Key.Ingredients, 
                    g.Key.BakerP,
                    g.Key.FlourP,
                    g.Key.BatchP,
                    g.Sum(r => double.Parse(r.Field<string>("KG")))
                };
             return row;
         }).CopyToDataTable();
