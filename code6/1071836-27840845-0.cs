    [TestClass]
    public class MyTest
    {
        IServices _service = null;
        [TestInitialize]
        public void Setup()
        {
            var isUnitTest = bool.Parse(ConfigurationManager.AppSettings["IsUnitTest"]);
            if (isUnitTest)
            {
                _service = new MockService();
            }
            else
            {
                _service = new Service();
            }
        }
.
.
.
