    public class When_Viewing_Global_Page : SpecsFor<MvcWebApp>
    {
        protected override void When()
        {
            //change to base url to the subdomain
            MvcWebApp.BaseUrl = "http://global.mylocaldomain.com";
            SUT.NavigateTo<HomeController>(c => c.Global());
        }
    
        [Test]
        public void Then_It_Shows_The_Project_Name()
        {
            string text = SUT.AllText();
            SUT.AllText().ShouldContain("This is the Global Page");
            //This will fail because the page contains "Not Found"
        }
        [TestFixtureTearDown]
        public void Cleanup()
        {
            //you have to change that back to the URL that was
            //set up in your SpecsForIntegrationHost
            MvcWebApp.BaseUrl = "http://mylocaldomain.com";
        }
    }
