    public class ParentChildrenTable
    {
      public int Id { get; set; }
      public int ParentId { get; set;}
      public int ChildId {get; set; }
    
      public virtual ParentTable Parent { get; set; }
      public virtual ChildrenTable Child { get; set; }
    }
