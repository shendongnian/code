      [SetUp]
      public void RunBeforeAllFixtures()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                _vm = new TestViewModel();
            
            }
