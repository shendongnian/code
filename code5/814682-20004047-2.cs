    public class MyModel
    {
         [ClientRequired("CompanyName")]
         public string Company { get; set; }
    }
    public class MyOtherModel
    {
         [ClientRequired("CompanyName")]
         public string Name { get; set; }
         public string Address { get; set; }
    }
