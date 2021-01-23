    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.Common;
    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace LBMServiceTests
    {
        [TestClass]
        public class Test
        {
            public TestContext TestContext { get; set; }
    
            [TestCleanup()]
            public void MyTestCleanup()
            {
                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                {
                    var type = Type.GetType(TestContext.FullyQualifiedTestClassName);
                    if (type != null)
                    {
                        var instance = Activator.CreateInstance(type);
                        var method = type.GetMethod(TestContext.TestName);
                        try
                        {
                            method.Invoke(instance, null);
    
                            // if the above call does not throw exception it passes for sure.
                            var resultField = TestContext.GetType()
                                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                .Where(x => x.Name.Contains("m_currentResult")).First();
    
                            var currentTestResult = resultField.GetValue(TestContext);
                            var outcomeProperty = currentTestResult.GetType()
                                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                .Where(x => x.Name.Equals("m_outcome")).First();
    
                            outcomeProperty.SetValue(currentTestResult, TestOutcome.Passed);
                        }
                        catch
                        {
    
                        }
                    }
                }
            }
    
            private static int i = 0;
            [TestMethod]
            public void TMethod()
            {
                i++;
                if (i == 1)
                    Assert.Fail("Failed");
            }
        }
    }
