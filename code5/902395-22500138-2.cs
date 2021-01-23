    public class JSTreeDTO
    {
    public string id{get;set;}
    public string text{get;set;}
    public string text{get;set;}
    public string parent {get;set;}
    public string icon{get;set;}
    public StateDTO state{get;set;}
    }
    public class StateDTO
    {
     public bool opened{get;set;}
     public bool selected{get;set;}
    }
