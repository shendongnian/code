    public class MyCommandDefinition
    {
        public string DisplayName {get;set;}
      
        public List<MyParameter> Parameters {get;set;}
    
        public Parameter SelectedParameter {get;set;}
    }
    public class MyParameter
    {
        public string DisplayName {get;set;}
       
        //Additional properties depending on your needs.
    }
