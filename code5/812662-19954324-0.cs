    public override void Up()
    {
      AddColumn("dbo.Plexes", "ISingleIsValidTimeInMinutes", c => c.Int(nullable: false));
      Sql("UPDATE Plexes SET ISingleIsValidTimeInMinutes = ISingleIsValidTime");
      DropColumn("dbo.Plexes", "ISingleIsValidTime");
    }
