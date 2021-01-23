    public class PurchaseOrder
    {
        public virtual int OrderID { get; set; }
        public virtual DateTime? OrderDate { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
    public class Product
    {
        public virtual int ProductID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<PurchaseOrder> Orders { get; set; }
    }
    public class PurchaseOrderMapping : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMapping()
        {
            Id(x => x.OrderID, "OrderID");
            Map(x => x.OrderDate, "OrderDate");
            HasManyToMany(x => x.Products)
                .Table("OrderProducts")
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
                .Table("OrderProducts")
                .Schema("dbo")
                .ParentKeyColumn("OrderID")
                .ChildKeyColumn("ProductID")
                .Inverse();
            Schema("dbo");
            Table("Product");
        }
    }
