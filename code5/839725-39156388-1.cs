    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace UnitTests.Utility
    {    
        /// <summary>
        /// Define and Run a list of ordered tests. 
        /// 2016/08/25: Posted to SO by crokusek 
        /// </summary>    
        public class OrderedTest
        {
            /// <summary>Test Method to run</summary>
            public Action TestMethod { get; private set; }
    
            /// <summary>Flag indicating whether testing should continue with the next test if the current one fails</summary>
            public bool ContinueOnFailure { get; private set; }
    
            /// <summary>Any Exception thrown by the test</summary>
            public Exception ExceptionResult;
    
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="testMethod"></param>
            /// <param name="continueOnFailure">True to continue with the next test if this test fails</param>
            public OrderedTest(Action testMethod, bool continueOnFailure = false)
            {
                TestMethod = testMethod;
                ContinueOnFailure = continueOnFailure;
            }
    
            /// <summary>
            /// Run the test saving any exception within ExceptionResult
            /// Throw to the caller only if ContinueOnFailure == false
            /// </summary>
            /// <param name="testContextOpt"></param>
            public void Run()
            {
                try
                {
                    TestMethod();
                }
                catch (Exception ex)
                {
                    ExceptionResult = ex;
                    throw;
                }
            }
    
            /// <summary>
            /// Run a list of OrderedTest's
            /// </summary>
            static public void Run(TestContext testContext, List<OrderedTest> tests)
            {
                Stopwatch overallStopWatch = new Stopwatch();
                overallStopWatch.Start();
    
                List<Exception> exceptions = new List<Exception>();
    
                int testsAttempted = 0;
                for (int i = 0; i < tests.Count; i++)
                {
                    OrderedTest test = tests[i];
    
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
    
                    testContext.WriteLine("Starting ordered test step ({0} of {1}) '{2}' at {3}...\n",
                        i + 1,
                        tests.Count,
                        test.TestMethod.Method,
                        DateTime.Now.ToString("G"));
    
                    try
                    {
                        testsAttempted++;
                        test.Run();
                    }
                    catch
                    {
                        if (!test.ContinueOnFailure)
                            break;
                    }
                    finally
                    {
                        Exception testEx = test.ExceptionResult;
    
                        if (testEx != null)  // capture any "continue on fail" exception
                            exceptions.Add(testEx);
    
                        testContext.WriteLine("\n{0} ordered test step {1} of {2} '{3}' in {4} at {5}{6}\n",
                            testEx != null ? "Error:  Failed" : "Successfully completed",
                            i + 1,
                            tests.Count,
                            test.TestMethod.Method,
                            stopWatch.ElapsedMilliseconds > 1000
                                ? (stopWatch.ElapsedMilliseconds * .001) + "s"
                                : stopWatch.ElapsedMilliseconds + "ms",
                            DateTime.Now.ToString("G"),
                            testEx != null
                                ? "\nException:  " + testEx.Message +
                                    "\nStackTrace:  " + testEx.StackTrace +
                                    "\nContinueOnFailure:  " + test.ContinueOnFailure
                                : "");
                    }
                }
    
                testContext.WriteLine("Completed running {0} of {1} ordered tests with a total of {2} error(s) at {3} in {4}",
                    testsAttempted,
                    tests.Count,
                    exceptions.Count,
                    DateTime.Now.ToString("G"),
                    overallStopWatch.ElapsedMilliseconds > 1000
                        ? (overallStopWatch.ElapsedMilliseconds * .001) + "s"
                        : overallStopWatch.ElapsedMilliseconds + "ms");
    
                if (exceptions.Any())
                {
                    // Test Explorer prints better msgs with this hierarchy rather than uisng 1 AggregateException().
                    throw new Exception(String.Join("; ", exceptions.Select(e => e.Message), new AggregateException(exceptions)));
                }
            }
        }
    }
