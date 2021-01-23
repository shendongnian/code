    public class Employee
    {
       [Key]
       public int ID { get; set; }
       [NotMapped]
       public string EmpID 
       { 
          get { return "0000" + ID.ToString();  }  // do whatever you need to do here!
       }
    }    
