    public class SO29047477
    {
        private List<TagType<object>> _tagList;
        [SetUp]
        public void TestSetup()
        {
            _tagList = new List<TagType<dynamic>>();
            _tagList.Add(new TagType<dynamic>() { FieldTag = "ID", Position = "ID1"});
            _tagList.Add(new TagType<dynamic>() { FieldTag = "PT", Position = "PT1" });
            _tagList.Add(new TagType<dynamic>() { FieldTag = "ID", Position = "ID2" });
            _tagList.Add(new TagType<dynamic>() { FieldTag = "EC", Position = "EC1" });
            
        }
    }
