    public class Data
    {
          // gets or sets the ID of this Data record.
          public int ID {get;set;}
          public string ImagePath {get;set;}
          // gets or sets the ID of the related CategoriesAdmin record.
          public int CategoriesAdminId {get;set;}
          // gets or sets the related CategoriesAdmin record. Entity Framework will
          // automatically populate this property with an object for the related
          // CategoriesAdmin record.
          [ForeignKey("CategoriesAdminId")]
          public virtual CategoriesAdmin CategoriesAdmin {get;set;}
          // other properties
          ...
    }
