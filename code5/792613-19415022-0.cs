    public partial class App : Application
    {
        public App()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RecognizePrefixes("Test_Person_");
                cfg.CreateMap<Test_Person, TestPersonFlattened>();
            }); 
            Mapper.CreateMap<Test_Person, TestPersonFlattened>();
            Mapper.AssertConfigurationIsValid();
        }
    }
    public class Test_Person
    {
        public Test_Person_Name Test_Person_PublicName { get; set; }
    }
    public class Test_Person_Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class TestPersonFlattened
    {
        public string PublicNameFirstName { get; set; } // This is what I call this property!
    }
