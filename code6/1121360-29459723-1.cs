    DateTime twoDaysAgo = DateTime.Now.AddDays(-2);
    var groupSummaries = _recipeContext.Groups.OrderBy(g => g.Name)
        .Select(g => new GroupSummaryModel{
            Id = g.Id,
            Name = g.Name,
            Description = g.Description,
            NumberOfUsers = g.Users.Count(),
            NumberOfNewRecipes = g.Recipes.Count(r => r.PostedOn > twoDaysAgo)
        });
