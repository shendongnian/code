    public class ContentBox
    {
      public int ContentDefinitionID { get; set; }
      ....
    }
    public class ContentBoxesVM
    {
      public IEnumerable<ContentBox> ContentBoxes { get; set; }
      public SelectList ContentBoxesSelectList { get; set; }
    }
