    var list = Enumerable.Range(1, 10)
                         .Select(i => new Document
                         {
                             ID = i.ToString(),
                             Type = "someType",
                             Checked = (i > 5)
                         }).ToList();
