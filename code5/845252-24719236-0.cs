    public override void Up()
    {
    AddColumn("dbo.ClientContacts", "FamilialRelationshipId", c => c.Int(nullable: false));
    CreateIndex("dbo.ClientContacts", "FamilialRelationshipId");
    AddForeignKey("dbo.ClientContacts", "FamilialRelationshipId", "dbo.FamilialRelationships",        "FamilialRelationshipId");
    }
