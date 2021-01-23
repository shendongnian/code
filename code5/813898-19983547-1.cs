    public class Birthdays
    {
      [XmlIgnore]
      public DateTime DateOfBirth {get;set;}
      [XmlElement("DateOfBirth")]
      public string DateOfBirthString
      {
        get { return this.DateOfBirth.ToString("yyyy-MM-dd"); }
        set { this.DateOfBirth = DateTime.Parse(value); }
      }
      public string Name {get;set;}
    }
