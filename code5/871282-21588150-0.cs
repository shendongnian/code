    Models.Ingredients ing = null;
    int? count = null;
    var popularity = QueryOver.Of<Models.RecipeIngredients>()
       .Where(p => p.Ingredient.IngredientId == ing.IngredientId)
       .ToRowCountQuery();
    
    var ingredients = session.QueryOver<Models.Ingredients>(() => ing)
       .SelectList(list => list
          .Select(p => p.IngredientId)
          .Select(p => p.DisplayName)
          .SelectSubQuery(popularity).WithAlias(() => count)
       )
       .OrderByAlias(() => count).Desc()
       .ThenBy(p => p.DisplayName).Asc()
       .List<Object[]>()
       .Select(i => new IngredientSource((Guid)i[0], (String)i[1]));
