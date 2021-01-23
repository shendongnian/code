        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
        }    
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
        }
