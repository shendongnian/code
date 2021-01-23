    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCompanyAndEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 100)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Guid(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("Employees", "CompanyId", "Companies", "Id");
            CreateIndex("Employees", "CompanyId");
        }
        //...
    }
