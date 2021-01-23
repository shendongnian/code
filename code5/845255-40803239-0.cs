        public override void Up()
        {
            CreateTable(
                "dbo.DecisionAccesses",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.DecisionPersonStatus",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);
            AddColumn("dbo.DecisionForm_DecisionFields", "DecisionAccessId", c => c.Int(nullable: false, defaultValue: (int)DecisionAccess.Creator));
            AddColumn("dbo.DecisionMatterPersons", "DecisionPersonStatusId", c => c.Int(nullable: false, defaultValue: (int)DecisionAccess.Creator));
            CreateIndex("dbo.DecisionForm_DecisionFields", "DecisionAccessId");
            CreateIndex("dbo.DecisionMatterPersons", "DecisionPersonStatusId");
            //I moved outcommented to next migration and ran the migrations in separate steps to avoid: (The object is dependent on column ALTER TABLE ALTER COLUMN failed because one or more objects access this column)
            //AddForeignKey("dbo.DecisionForm_DecisionFields", "DecisionAccessId", "dbo.DecisionAccesses", "Id", cascadeDelete: true); 
            //AddForeignKey("dbo.DecisionMatterPersons", "DecisionPersonStatusId", "dbo.DecisionPersonStatus", "Id", cascadeDelete: true);
        }
        public override void Down()
        {
            //Moved to next migration
            //DropForeignKey("dbo.DecisionMatterPersons", "DecisionPersonStatusId", "dbo.DecisionPersonStatus");
            //DropForeignKey("dbo.DecisionForm_DecisionFields", "DecisionAccessId", "dbo.DecisionAccesses");
        }
