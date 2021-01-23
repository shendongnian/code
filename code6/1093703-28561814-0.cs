    public class Data
    {
         public string Method { get; set; }
         public Skills Skill { get; set; }
         // If you don't want to use Skills class then you can use this
         //public Dictionary<int, string> Skills { get; set; }
    }
    public class Skills
    {
         public int Id { get; set; }
         public string Skill { get; set; }
    }
