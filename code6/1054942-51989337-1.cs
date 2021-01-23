    public override void Up()
    {
        AddColumn("dbo.MyTable", "MyColumn", c => c.String());
        Sql("UPDATE dbo.MyTable SET MyColumn = COALESCE(SomeOtherColumn, 'My Fallback Value')");
        AlterColumn("dbo.MyTable", "MyColumn", c => c.String(nullable: false));
    }
        
    public override void Down()
    {
        DropColumn("dbo.MyTable", "MyColumn");
    }
