    public class Medule
    {
    
        //Constructor   
        public Medule()
        {
            Questions = new HashSet<Question>();
        }
    
        //List of Module properties
        public ModuleId {get; set;}
    
        
        //Question
        public virtual ICollection<Question> Questions { get; set; }
    
    }
