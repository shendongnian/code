    ...
    Category = categories.GetNameFromId(i.result.CategoryId)
    ...
    public static string GetNameFromId(this IEnumerable<Category> categories, string id)
    {
        return categories.Any(c => c.Id.Equals(id)) ?
                     categories.First(c => c.Id.Equals(id)).Name : 
                     null
    }
