    public class student
    {      
       public List<Task> Task { get; set; }      
       public string Name { get; set; } 
       public int ID { get; set; }
            
       public Student()
       {
         this.Task = new List<Task>();
       }
    }
    
