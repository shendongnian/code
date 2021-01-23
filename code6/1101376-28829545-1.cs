    public class Customer
    {
        [Key]
        public int Number { get; set; }
    
        // One customer has many machines, so the `MachID` SHOULD NOT exist.
        // public string MachID { get; set; }
        // [ForeignKey("MachID")]
        public virtual List<Machine> Machines { get; set; }
    }
    
    public class Machine
    {
    
        [Key]
        public string SN { get; set; }
        ...
    
        public int CustID { get; set; }
        [ForeignKey("CustID")]
        public virtual Customer Customer { get; set; }
    }
