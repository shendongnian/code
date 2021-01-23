    public class OrderDTO
    {
        // Attributes
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
    
        // Collection of Products
        IEnumerable<ProductDTO> Products { get; set; }
    }
