    public override void Up()
    {
        // ... 
        CreateIndex("tableName", "columnName", unique: true, name: "myIndex");
    }
    public override void Down()
    {
        // ...
        DropIndex("tableName", "myIndex");
    }
