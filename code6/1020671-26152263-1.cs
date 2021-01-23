        var type = typeof (Book); //or var type=instance.GetType();
        var res=type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(
                p =>
                    (p.GetCustomAttribute<ColumnAttribute>() ?? new ColumnAttribute()).Value == "Bok_Name");
