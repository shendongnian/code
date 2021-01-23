    class Class1 {
         public string id { get; set; }
         public int rowNumber { get; set; }
         public int parentId { get; set; }
         public bool expanded { get; set; }
         public string format{ get; set; }
         public List <Cells> cells {get; set;}
    }
    class Cells {
      public string columnId {get; set;}
      public string type{get; set;}
      public bool value{get; set;}
      public string format {get; set;}
