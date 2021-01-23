    public static List<someclass> OrderAsc(
    List<someclass> object, 
    specific_field_by_someone )
    {
        Dictionary<string, Func<someclass,object>> data_table = new Dictionary<string, Func<someclass,object>>() {
            {"id", x => x.id },
            {"name", x => x.name }
        }
        return object.OrderBy(data_dable["name"]);
    }
