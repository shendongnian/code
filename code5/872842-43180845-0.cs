    public class TestClassConfig
    {
      [Category("CatWithExpandObj")]
      [ExpandableObject]
       public ExpandableTest OtherClass { get; set; } = new ExpandableTest();
    }
