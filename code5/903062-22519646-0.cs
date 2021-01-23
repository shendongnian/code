    public class Mark
    {
    public string markname { get; set; }
    public int mark { get; set; }
    }
    public class SubjectSubcategory
    {
    public string name { get; set; }
    public List<Mark> Marks { get; set; }
    }
    public class SubjectCategory
    {
    public string name { get; set; }
    public List<SubjectSubcategory> Subject_subcategory { get; set; }
    }
     public class Major
    {
    public string name { get; set; }
    public List<SubjectCategory> Subject_category { get; set; }
     }
     public class Frequency
     {
    public string name { get; set; }
    public List<Major> Major { get; set; }
     }
    public class Product
    {
    public string studentname { get; set; }
     public List<Frequency> frequency { get; set; }
     }
    public class RootObject
    {
    public List<Product> product { get; set; }
    }
