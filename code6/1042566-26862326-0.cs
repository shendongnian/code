    namespace MigrationsDemo.Migrations 
    { 
        using System; 
        using System.Data.Entity.Migrations; 
         
        public partial class AddPostClass : DbMigration 
        { 
            public override void Up() 
            { 
                CreateTable( 
                    "dbo.Posts", 
                    c => new 
                        { 
                            PostId = c.Int(nullable: false, identity: true), 
                            Title = c.String(maxLength: 200), 
                            Content = c.String(), 
                            BlogId = c.Int(nullable: false), 
                        }) 
                    .PrimaryKey(t => t.PostId) 
                    .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true) 
                    .Index(t => t.BlogId) 
                    .Index(p => p.Title, unique: true); 
     
                AddColumn("dbo.Blogs", "Rating", c => c.Int(nullable: false, defaultValue: 3)); 
            } 
             
            public override void Down() 
            { 
                DropIndex("dbo.Posts", new[] { "Title" }); 
                DropIndex("dbo.Posts", new[] { "BlogId" }); 
                DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs"); 
                DropColumn("dbo.Blogs", "Rating"); 
                DropTable("dbo.Posts"); 
            } 
        } 
    } 
