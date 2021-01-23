    public class Product
    {
        private ProductDet ProductDet1 { get; set; }
        private ProductDet ProductDet2 { get; set; }
        protected Product() { } // make NHibernate happy
        public Product(int productionLine, int productNumber) : this(new ProductKey(productionLine, productNumber)) { }
        public Product(ProductKey key)
        {
            Key = key;
            ProductDet1 = new ProductDet { ProductKey = Key };
            ProductDet2 = new ProductDet { ProductKey = Key };
        }
        public virtual int ID { get; protected set; }
        public virtual ProductKey Key { get; protected set; }
        public virtual string Det1
        {
            get { return ProductDet1.Value; }
            set { ProductDet1.Value = value; }
        }
        public virtual string Det2
        {
            get { return ProductDet2.Value; }
            set { ProductDet2.Value = value; }
        }
    }
    public class ProductKey
    {
        protected ProductKey() { } // make NHibernate happy
        public ProductKey(int productionLine, int productNumber)
        {
            ProductionLine = productionLine;
            ProductNumber = productNumber;
        }
        public virtual int ProductionLine { get; private set; }
        public virtual int ProductNumber { get; private set; }
        public override bool Equals(object obj)
        {
            var other = obj as ProductKey;
            return other != null && other.ProductionLine == this.ProductionLine && other.ProductNumber == this.ProductNumber;
        }
        public override int GetHashCode()
        {
            return (ProductionLine << 16) + ProductNumber;
        }
    }
    public class ProductDet
    {
        public virtual ProductKey ProductKey { get; set; }
        public virtual string Value { get; set; }
    }
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ID);
            Component(x => x.Key, c =>
            {
                c.Map(k => k.ProductionLine).UniqueKey("product_key");
                c.Map(k => k.ProductNumber).UniqueKey("product_key");
            });
            MapProductDetReference("ProductDet1");
            MapProductDetReference("ProductDet2");
        }
        private void MapProductDetReference(string entityName)
        {
            References(Reveal.Member<Product, ProductDet>(entityName))
                .Columns("ProductionLine", "ProductNumber")
                .ReadOnly()
                .EntityName(entityName)
                .Cascade.All()
                .Fetch.Join()
                .Not.LazyLoad();
        }
    }
    public abstract class ProductDetMap : ClassMap<ProductDet>
    {
        public ProductDetMap()
        {
            CompositeId(x => x.ProductKey)
                .KeyProperty(k => k.ProductionLine)
                .KeyProperty(k => k.ProductNumber);
            Map(x => x.Value, "TheValue");
        }
    }
    public class ProductDet1Map : ProductDetMap
    {
        public ProductDet1Map()
        {
            EntityName("ProductDet1");
            Table("ProductDet1");
        }
    }
    public class ProductDet2Map : ProductDetMap
    {
        public ProductDet2Map()
        {
            EntityName("ProductDet2");
            Table("ProductDet2");
        }
    }
