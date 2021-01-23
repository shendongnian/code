    public class worldData {
      public string Text { get; set; }
      public string Icon { get; set; }
      public int sectionID { get; set; }
    } 
    
    // notice I had to change your classname
    // because membernames cannot be the same as their typename 
    public class worldroot
    {
            public worldData world { get; set; }
    }
