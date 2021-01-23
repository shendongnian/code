    public class GroupVM
    {
      public int ID { get; set; }
      public string DisplayName { get; set; }
      public bool IsMember { get; set; }
    }
    public class MyModelVM
    {
      public int ID {get; set; }
      // any other properties of the model you want to display
      public List<GroupVM> Groups { get; set; }
    }
