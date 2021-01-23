    public override void Up()
    {
        AddColumn("dbo.MyClasses", "Name", c => c.String());
        Sql("UPDATE dbo.MyClasses SET Name = [Key]"); //Manually added to migration
        DropColumn("dbo.MyClasses", "Key");
    }
        
    public override void Down()
    {
        AddColumn("dbo.MyClasses", "Key", c => c.String());
        Sql("UPDATE dbo.MyClasses SET [Key] = Name"); //Manually added to migration
        DropColumn("dbo.MyClasses", "Name");
    }
