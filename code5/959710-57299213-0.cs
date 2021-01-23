    //AlterColumn("dbo.AspNetRoles", "Id", c => c.Int(nullable: false, identity: true));
    DropColumn("dbo.AspNetRoles", "Id");
    AddColumn("dbo.AspNetRoles", "Id", c => c.Int(nullable: false, identity: true));
    
    // ...
    //AlterColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
    DropColumn("dbo.AspNetUsers", "Id");
    AddColumn("dbo.AspNetUsers", "Id", c => c.Int(nullable: false, identity: true));
