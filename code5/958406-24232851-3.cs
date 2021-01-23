    public class MyDescription : Attribute
    {        
        public string Description = { get; private set; }
        public MyDescription(string description)
        {
           Description = description;
        }
    }
