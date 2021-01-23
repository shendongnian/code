    public class student
    {      
        public student()
        {
           Task = new List<Task>();
        }
        public List<Task> Task { get; set; }      
        public string Name { get; set; } 
        public int ID { get; set; }
    }
