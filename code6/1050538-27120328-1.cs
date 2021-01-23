    public class TestCase
    {
        public string StoryName { get; set; }
        public string ScenarioName { get; set; }
        public string TestCaseName { get; set; }
        public int ResponseCode { get; set; }
        public List<UserDetail> userDetails { get; set; }
    }
    
    public class UserDetail
    {
        public DateTime DateOfBirth { get; set; }
    }
