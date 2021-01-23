    internal static void bind<T>(List<T> list, DropDownList ddl)
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
