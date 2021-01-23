    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      [TestFixture]
      public class SuccessTests
      {
        [Test]
        [Category("Long")]
        public void VeryLongTest()
        { /* ... */ }
    }
