    public class Anything
    {
        private List<string> PPP = new List<string>()
        { 
            "table", 
            "chair", 
            "spoon", 
            "bread"
        };
        
        private string _name;
    
        // Public property to have access for reading it outside the class but 
        // with private setter to set it only inside class
        public string Name {
           get { return _name; } 
           private set { 
               // Use linq to verify name
               if(PPP.Contains(value))
               {
                   _name = value;
               }
               else
               {
                   string message = string.Format("{0} is not acceptable value!", value)
                   throw new InvalidOperationException(message);
               }              
           } 
        };
    
        // Constructor
        public  Anything(string name)
        {
             this.Name = name;
        }
    }
