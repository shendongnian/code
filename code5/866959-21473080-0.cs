     public class Category : SystmApp_Object {
    public GUID UID {get; set;}
                public string Name { get; set; }
                [DisplayName("Parent Category")]
                public virtual Guid? CategoryUID { get; set; }
            }
