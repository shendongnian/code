    public override void Up()
    {
        //DropIndex("dbo.PurchaseManifestLines", new[] { "PurchaseOrderLineId" });
        //RenameColumn(table: "dbo.PurchaseManifestLines", name: "PurchaseOrderLineId", newName: "PurchaseOrderLine_Id1");
        //AddColumn("dbo.PurchaseManifestLines", "PurchaseOrderLine_Id", c => c.Int(nullable: false));
        //AlterColumn("dbo.PurchaseManifestLines", "PurchaseOrderLine_Id1", c => c.Int());
        //CreateIndex("dbo.PurchaseManifestLines", "PurchaseOrderLine_Id1");
        // gives error Column names in each table must be unique. Column name 'PurchaseOrderLine_Id' in table 'dbo.PurchaseManifestLines' is specified more than once.
        //replaced with 
        DropIndex("dbo.PurchaseManifestLines", new[] { "PurchaseOrderLineId" });
        DropColumn("dbo.PurchaseManifestLines", "PurchaseOrderLineId");
    }
