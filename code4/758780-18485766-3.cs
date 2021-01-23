    namespace MyNamespace.Tests
    {
        using System;
        using NUnit.Framework;
    
        [SetUpFixture]
        public class TestsSetupClass
        {
            [OneTimeSetUp]
            GlobalSetup()
            {
                // Do login here.
            }
    
            [OneTimeTearDown]
            GlobalTeardown()
            {
                // Do logout here
            }
        }
    }
