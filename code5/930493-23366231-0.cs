    public enum eWhatAmI
    {
       ListedObjects,
       StringArrays,
       Other   
    }
    
    public interface IWhatParmType
    {
       eWhatAmI whatAmI { get; set; }
    }
    
    public class MyListVersion : IWhatParmType
    {
       public eWhatAmI whatAmI { get; set; }
       public List<string> whatever { get; set; }
    
       public MyListVersion()
       {
          whatAmI = eWhatAmI.ListedObjects;
          whatever = new List<string>();
          ... build out list of strings
       }
    }
    
    public class MyArrayVersion : IWhatParmType
    {
       public eWhatAmI whatAmI { get; set; }
       public string[] whatever { get; set; }
    
       public MyArrayVersion()
       {
          whatAmI = eWhatAmI.StringArrays;
          ... build out array of strings
       }
    }
