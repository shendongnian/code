    public interface IQProvider
    {
        string Q { get; set; }
    }
    
    class SettingsA : IQProvider
    {
       public string Name{get;set;}
       public string Rank{get;set;}
       public string Serial{get;set;}
       public string Active{get;set;}
       public string Q { get; set; }
    }
