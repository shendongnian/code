    public class FirstModel
    {
        public int Id { get; set; }
        public string SomeProperty { get; set; }
    }
    
    public class SecondModel
    {
        public int Id { get; set; }
        public string SomeOtherProperty { get; set; }
    }
    
    public class ViewModel
    {
        public FirstModel MyFirstModel { get; set; }
        public SecondModel MySecondModel { get; set; }
    }
