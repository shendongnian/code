Migration\DATE_initial.cd
        public override void Up(MigrationBuilder migrationBuilder)
        {
    ....
            migrationBuilder.DropColumn("AspNetUsers", "NormalizedEmail"); \\ remove the -
    ....
            migrationBuilder.CreateTable("AspNetRoles",
                c => new
                    {
                        Id = c.String(false), \\ set Id not nullable
                        Name = c.String()
                    })
                .PrimaryKey("PK_AspNetRoles", t => t.Id);
     ....
            migrationBuilder.CreateTable("AspNetUsers",
                c => new
                    {
                        Id = c.String(false), \\ set Id not nullable
                        AccessFailedCount = c.Int(nullable: false),
     ....
