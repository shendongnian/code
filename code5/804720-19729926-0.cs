    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCollected { get; set; }
        public decimal OrderTotal { get; set; }
        public Student Student { get; set; }
        //add any view specific properties, if needed like IsEditable
    }
