    public override void Up()
    {
      AddColumn("dbo.Plexes", "ISingleIsValidTimeInMinutes", c => c.Int(nullable: false));
      Sql("UPDATE Plexes SET ISingleIsValidTimeInMinutes = -DATEDIFF(MINUTE, ISingleIsValidTime, 0)");
      DropColumn("dbo.Plexes", "ISingleIsValidTime");
    }
