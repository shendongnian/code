    internal static void bind(IEnumerable list, DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            ddl.Items.Add(li);
            ddl.DataSource = list;
            ddl.DataBind();
        }
        catch (Exception)
        { }
    }
