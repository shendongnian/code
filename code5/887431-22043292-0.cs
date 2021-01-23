    public class ActionType {
      public ActionType() {
      }
      public string Id { get; set; }
      public string FName { get; set; }
    }
  
    public class ActionTypeList : List<ActionType> {
      public ActionTypeList() {
        Add(new ActionType() { Id = "2", FName = "hanumanji" });
        Add(new ActionType { Id = "4", FName = "temples" });
        Add(new ActionType { Id = "38", FName = "books" });
        Add(new ActionType { Id = "28", FName = "stories" });
      }
    }
