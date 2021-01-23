    public override void Up()
    {
        DropPrimaryKey("dbo.MyClasses");
        AddColumn("dbo.MyClasses", "ID", c => c.Int(nullable: false, identity: true));
        AlterColumn("dbo.MyClasses", "Key", c => c.String());
        AddPrimaryKey("dbo.MyClasses", "ID");
    }
