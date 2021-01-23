    public class Movie
    {
      ....
      [XmlArray("genre")]
      [XmlArrayItem("Name")]
      public string[] Genre { get; set; }
    }
