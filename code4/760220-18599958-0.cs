    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class UtilitiesTests
    {
        [TearDown]
        public void TearDown()
        {
            //using console here just for sake of simplicity. 
            Console.WriteLine(String.Format("{0}: {1}", TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Result.Status));
        }
    
        [Test]
        public void CleanFileName()
        {
            var cleanName = "my &file%123$99\\|/?\"*:<>.jpg";
            Assert.AreEqual("my &file%123$99\\|/?\"*:<>.jpg", cleanName);
        }
    }
