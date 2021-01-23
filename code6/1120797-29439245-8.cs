    public class Child
    {
       public int ChildId {get; set;}
       [ForeignKey("Parent")]
       public int ParentId {get; set;}
       public virtual Parent Parent{get;set;}
    }
