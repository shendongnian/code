     var row = dt.NewRow();
     row.ItemArray = new object[]
       {
          g.Key, 
          g.Sum(r => double.Parse(r.Field<string>("KG"))),
          g.Sum(r => double.Parse(r.Field<string>("BakerP"))), // assuming this is also a number saved as a string
          // etc.
       };
     return row;
