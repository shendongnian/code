    public class Contract
    {
       [Key]
       public int ID { get; set; }
       public string Name { get; set; }
    
       [ForeignKey("BusinessType")]
       public int BusinessTypeID { get; set; }
    
       [ForeignKey("ContractType")]
       public int ContractTypeID { get; set; }
    
       public virtual CodeValue BusinessType { get; set; }
       public virtual CodeValue ContractType { get; set; }
    }
