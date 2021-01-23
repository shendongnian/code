    dataTable.Rows.Cast<DataRow>()
        .GroupBy(r => new { Id = r.Field<int>("Id"), DisplayName = r.Field<string>("DisplayName") })
        .Select(g => new Product()
        {
            Id = g.Key.Id,
            DisplayName = g.Key.DisplayName,
            Ingredients = g.Select(r => new Ingredient()
            {
                id = r.Field<int>("IngredientId"),
                Name = r.Field<string>("IngName")
            }).ToArray()
        });
