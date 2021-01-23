    public static string GetSearchValue(DataGrid obj) {
        return (string)obj.GetValue(SearchValueProperty);
    }
    public static void SetSearchValue(DataGrid obj, string value) {
        obj.SetValue(SearchValueProperty, value);
    }
