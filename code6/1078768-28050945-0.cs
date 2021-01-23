    private IOrderedQueryable<Title> AddOrderBy(this IQueryable<Title> Results, int ColumnNumber, bool OrderByDesc)
    {
        switch (ColumnNumber)
        {
            case 1:
                if (OrderByDesc)
                    return Results.OrderByDescending(t => t.FK_ContentType);
               else
                    return Results.OrderBy(t => t.FK_ContentType);
                break;
            case 2:
                if (OrderByDesc)
                    return Results.OrderByDescending(t => t.TitleFullName);
                else
                    return Results.OrderBy(t => t.TitleFullName);
                break;
            default:
                if (OrderByDesc)
                    return Results.OrderByDescending(t => t.ID);
                else
                    return Results.OrderBy(t => t.ID);
                break;
        }
    }
