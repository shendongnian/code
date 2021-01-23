    public static List<DropdownList> getDropdownList(string Method)
    {
        using (var Context = new WebDataContext())
        {
            var toReturn = Context.ExecuteQuery<DropdownList>("EXEC " + Method).ToList();
            return toReturn;
        } 
    }
