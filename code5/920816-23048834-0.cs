    [Table("Drivers")]
    public class Driver
    {
       [Key]
       public int DriverId { get; set; }
       public String Name { get; set; }
       public String Phone { get; set; }
       public virtual ICollection<Job> Jobs {get; set;}
    }
