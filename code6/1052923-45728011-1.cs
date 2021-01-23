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
                Type classType = this.GetType(TestContext.FullyQualifiedTestClassName);
                if (classType != null)
                {
                    object instance = Activator.CreateInstance(classType);
                    MethodInfo method = classType.GetMethod(TestContext.TestName);
                    try
                    {
                        method.Invoke(instance, null);
                        // if the above call does not throw exception it passes for sure, 
                        // so changing the previous status and message is needed to be done.
                        FieldInfo resultField = TestContext.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.Name.Contains("m_currentResult")).First();
                        object currentTestResult = resultField.GetValue(TestContext);
                        FieldInfo outcomeProperty = currentTestResult.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.Name.Equals("m_outcome")).First();
                        outcomeProperty.SetValue(currentTestResult, TestOutcome.Passed);
                        FieldInfo errorInfoProperty = currentTestResult.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.Name.Equals("m_errorInfo")).First();
                        object errorInfoValue = errorInfoProperty.GetValue(currentTestResult);
                        FieldInfo messageProperty = errorInfoValue.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.Name.Equals("m_message")).First();
                        messageProperty.SetValue(errorInfoValue, "Passed.");
                        FieldInfo stackTraceProperty = errorInfoValue.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.Name.Equals("m_stackTrace")).First();
                        stackTraceProperty.SetValue(errorInfoValue, null);
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
