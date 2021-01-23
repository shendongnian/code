    public class PurchaseOrderMapping : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMapping()
        {
            Id(x => x.OrderID, "OrderID");
            Map(x => x.OrderDate, "OrderDate");
            HasManyToMany(x => x.Products)
                .Table("PurchaseOrderToProducts")
                .Schema("dbo")
                .ParentKeyColumn("ProductID")
                .ChildKeyColumn("OrderID")
                .Cascade.All();
            Schema("dbo");
            Table("PurchaseOrder");
        }
    }
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Id(x => x.ProductID, "ProductID");
            Map(x => x.Name, "Name");
            HasManyToMany(x => x.Orders)
                .Table("PurchaseOrderToProducts")
                .Schema("dbo")
                .ParentKeyColumn("OrderID")
                .ChildKeyColumn("ProductID")
                .Inverse();
            Schema("dbo");
            Table("Product");
        }
    }
