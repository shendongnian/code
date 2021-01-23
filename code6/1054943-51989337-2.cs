    public override void Up()
    {
        AddColumn("dbo.MyTable", "MyColumn", c => c.String(defaultValue: "Some Value", nullable: false));
        AlterColumn("dbo.MyTable", "MyColumn", c => c.String(nullable: false));
    }
        
    public override void Down()
    {
        DropColumn("dbo.MyTable", "MyColumn");
    }
