    public partial class Category
    {
       public int CategoryId {get;set;}
       public string CategoryName {get;set;}
       public IList<CustomField> CustomFields {get;set;}
    }
    public class CustomField
    {
       public int CustomFieldId {get;set;}
       
       public string FieldName {get;set;}
       public string FieldValue {get;set;}
       [ForeignKey("Category")]
       public int CategoryId {get;set;}
       public Category Category {get;set;}
    }
