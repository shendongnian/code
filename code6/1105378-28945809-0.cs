    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable) where T : ISelectList
    {
        var list = enumerable.ToList();
        if (list.Any())
        {
            return list.Select(l => new SelectListItem() { Text = l.Name, Value = l.Id.ToString() });
            // We can use an interface to define that any type that 
            //has 2 properties (Name and Id) can be converted into a select list.
    
        }
        return Enumerable.Empty<SelectListItem>();
    }
    
    public interface ISelectList
    {
        string Name { get; set; }
        int Id { get; set; }
    }
