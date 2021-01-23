    public class TestClassConfig
    {
       [Category("Cat1")]
       public string ExcelName { get; set; }
       
       [Category("Cat1")]
       public string ResultFolder { get; set; }
    
       [Category("CatWithExpandObj")]
       [ExpandableObject]
       public ExpandableTest OtherClass { get; set; }
    }
    
    public class ExpandableTest
    {
       public string Test1 { get; set; }
       public string Test2 { get; set; }
    }
