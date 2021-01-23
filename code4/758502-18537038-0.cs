    public static ICreateTableColumnOptionOrWithColumnSyntax WithUser(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
    {
        return tableWithColumnSyntax
            .WithColumn("UserId")
                .AsInt32()
                .Nullable()
                .ForeignKey("Users", "Id");
    }
