    #if NUNIT
    using NUnit.Framework;
    using TestClass = NUnit.Framework.TestFixtureAttribute;
    using TestMethod = NUnit.Framework.TestAttribute;
    using TestInitialize = NUnit.Framework.SetUpAttribute;
    using TestCleanup = NUnit.Framework.TearDownAttribute;
    using IgnoreAttribute = NUnit.Framework.IgnoreAttribute;
    #else
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;
    #endif
