    Up()
    {
        CreateTable("dbo.Color"...);
        DropColumn("FavoriteColor");
        AddColumn("FavoriteColor", c=>Int(nullable: false));
    // Some other code
    }
