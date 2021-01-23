    [Serializable]
    public class ProgramInfo
    {
      public string Name { get; set; }
      public string VersionValue 
      { 
        get;
        set{
           VersionValue = value;
           //Private method to parse
           VersonType = parseAndReturnVersionType(value);
           } 
      }
      public Version VersionType { get; set; }
    }
