    [Serializable]
    public class ProgramInfo
    {
      private string _versionValue;
      public string Name { get; set; }
      public string VersionValue 
      { 
        get
        {
          return _versionValue;
        }
        set{
           _versionValue = value;
           //Private method to parse
           VersonType = parseAndReturnVersionType(value);
           } 
      }
      public Version VersionType { get; set; }
    }
