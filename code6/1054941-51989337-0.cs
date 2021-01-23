    public override void Up()
    {            
        AddColumn("dbo.MyTable", "MyColumn", c => c.String(nullable: false));
    }
        
    public override void Down()
    {
        DropColumn("dbo.MyTable", "MyColumn");
    }
