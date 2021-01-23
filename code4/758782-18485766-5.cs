    namespace MyNamespace.Tests
    {
        using System;
        using NUnit.Framework;
    
        [SetUpFixture]
        public class TestsSetupClass
        {
            [OneTimeSetUp]
            public void GlobalSetup()
            {
                // Do login here.
            }
    
            [OneTimeTearDown]
            public void GlobalTeardown()
            {
                // Do logout here
            }
        }
    }
