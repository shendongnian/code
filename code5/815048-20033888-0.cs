    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using System;
    
    namespace ExceptionHandlingExamples
    {
        class Program
        {
            public static void Main(string[] args)
            {
                try
                {
                    TestExceptionManager();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
    
                Console.ReadLine();
            }
    
            private static void TestExceptionManager()
            {
                IConfigurationSource config = ConfigurationSourceFactory.Create();
                ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);
                Logger.SetLogWriter(new LogWriterFactory().Create());
    
                ExceptionManager exceptionManager = factory.CreateManager();
    
                exceptionManager.Process(MyExceptionCode, "Policy");
            }
    
            private static void MyExceptionCode()
            {
                throw new Exception("A basic Exception");
            }
        }
    }
