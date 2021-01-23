    public class Thing1Model()
    {
     public int type {get; set; }
     public string Name {get; set;}
    }
    
    public class Thing2Model() : Thing1Model
    {
      public DateTime MyDate {get; set;}
    }
