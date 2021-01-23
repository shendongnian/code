    public interface ICriterion
    {
       string SomeProperty {get; set;}
    }
    
    public class StringFieldCriterion : ICriterion
    {
       public string SomeProperty {get; set;}
       public string Value {get; set;}
    }
    
