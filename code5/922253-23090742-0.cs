    public class Man
        {
            public Man() 
            { 
            }
            [Key]
            public int idMan; { get; set; }
            [Required]
            public string ManName { get; set; }
    
            public virtual ICollection<Computer> listComputersBought { get; set; }
            public virtual ICollection<Computer> listComputersSold { get; set; }
    
        }
    public class Computer
        {
            public Computer() 
            {
            }
            [Key]
            public int idComputer{ get; set; }            
            public string ComputerName {get;set;}
    
            [ForeignKey("ManBuyer")]
            public int idMan{ get; set; }
    
            public virtual Man ManBuyer { get; set; }
        }
