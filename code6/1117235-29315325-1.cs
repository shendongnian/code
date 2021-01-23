    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Text;
    
    namespace UnitTestProject3
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                int lowerRange = 1;
                int upperRange = 10;
                string filename = @"c:\\development\test.txt";
                Random r = new Random();
                int number = 0;
    
                using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
                {
                    for (int i = 1; i < 500; i++)
                    {
                        number = r.Next(lowerRange, upperRange);
    
                        writer.Write(number + ",");
    
                    }
                    writer.Flush();
                    writer.Close();
                }
    
            }
        }
    }
