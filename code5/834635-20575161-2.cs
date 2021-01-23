    public static List<user> GetUsersFromListBox(ListBox source)
    {
        var returnValue = new List<user>();
        foreach(var item in source.Items)
        {
            returnValue.Add(new user() {
                id = item.Value,
                full_name = item.Text    
            });
        }
        return returnValue;
    }
