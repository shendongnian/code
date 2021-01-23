    public class MyDescription : Attribute
    {        
        public string Description = String.Empty;
        public MyDescription(string description)
        {
           Description = description;
        }
    }
