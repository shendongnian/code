    public static SelectList ToSelectList<T>(this Enum value, 
                                             Func<Enum, bool> filter, 
                                             Func<Enum, T> order,
                                             bool orderAsc = true,
                                             Object selected = null)
    {
        //get all values from the enum
        IEnumerable<Enum> temp = Enum.GetValues(value.GetType()).Cast<Enum>();
        //filter if required
        if (filter != null)
        {
            temp = temp.Where(filter);
        }
        //order if required
        if (order != null)
        {
            temp = orderAsc ? temp.OrderBy(order) : temp.OrderByDescending(order);
        }
        //map to a SelectList
        return new SelectList(temp.Select(x =>
            new
            {
                Value = Convert.ToInt32(x),
                Description = x.Attribute<DescriptionAttribute>().Description
            }), "Value", "Description", selected);
    }
