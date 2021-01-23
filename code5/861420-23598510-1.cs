    public abstract Given_Two_Engines {
        protected Given_An_Engine engine1 = new Given_An_Engine.That_Is_Stopped();
        protected Given_An_Engine engine2 = new Given_An_Engine.That_Is_Stopped();
        [SetUp]
        public void GivenTwoEngines() {
            engine1.RunSetUp();
            engine2.RunSetUp();
        }
        [TearDown]
        public void UnGivenTwoEngines() {
            engine2.RunTearDown();
            engine1.RunTearDown();
        }
 
