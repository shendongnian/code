    public override void Up()
        {
            AddColumn("dbo.OrderForms", "OrderRecieveDate", c =>
             c.DateTime(nullable: false, defaultValue: new DateTime(1000, 1, 1)));
            AddColumn("dbo.OrderForms", "OrderMadeDate", d =>
            d.DateTime(nullable: false, defaultValue: new DateTime(1000, 1, 1)));
    
        }
