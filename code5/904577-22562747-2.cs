    dataTable.Rows.Cast<DataRow>()
        .GroupBy(r => new { Id = r["Id"], DisplayName = r["DisplayName"] })
        .Select(g => new Product()
        {
            Id = (int)g.Key.Id,
            DisplayName = (string)g.Key.DisplayName,
            Ingredients = g.Select(r => new Ingredient()
            {
                id = (int)r["IngredientId"],
                Name = (string)r["IngName"]
            }).ToArray()
        });
