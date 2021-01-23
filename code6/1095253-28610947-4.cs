    internal class GlobalListTable
    {
        public ProductGroupTable ProductGroupTable { get; set; }
        public int ProductListTypeId { get; set; }
    }
    internal class ProductGroupTable
    {
        public List<ProductTable> ProductTables { get; set; }
    }
    internal class ProductTable
    {
        public List<ComponentTable> ComponentTables { get; set; }
    }
    internal class ComponentTable
    {
        public string Name { get; set; }
        public int ComponentTypeId { get; set; }
    }
