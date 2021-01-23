    class Tests {
        // these are needed on every test
        APIContext apicon;
        XRepository xRep;
        Controller controller;
        RelevantFactoryModel update;
        [TestInitialize]
        public void TestInitialize()
        {
            apicon = new APIContext();
            xRep = new xRepository(apicon);
            controller = new relevantController(cRep);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            update = new relevantFactoryModel();
        }   
    }
