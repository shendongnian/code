        var type = typeof (Book);
        var res=type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(
                p =>
                    (p.GetCustomAttribute<ColumnAttribute>() ?? new ColumnAttribute()).Value == "Bok_Name");
