    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                string[] arrID = { "111", "222", "333", "444", "555", "666", "777" };
    
                DateTime[] arrDates = new DateTime[]
                {
                    new DateTime(2015, 03, 20),
                    new DateTime(2015, 03, 20),
                    new DateTime(2015, 03, 20),
                    new DateTime(2015, 03, 21),
                    new DateTime(2015, 03, 21),
                    new DateTime(2015, 03, 20),
                    new DateTime(2015, 03, 20)
                };
    
                string[] arrTime = { "8:20", "8:40", "8:20", "9:10", "8:20", "9:10", "8:20" };
    
                int i = -1;
                int index = 0;
                List<ewansObject> l2 = arrID.Select(o => new ewansObject() { date = arrDates[++i].ToString(), time = arrTime[i], id = arrID[i] }).GroupBy(k => k.date + k.time).Select(o => new ewansObject() { index = index++.ToString(), date = o.First().date, time = o.First().time, id = String.Join(",", o.Select(x => x.id)) }).ToList(); ;
    
                string[] arrNEWID = l2.Select(x => x.id).ToArray();
                string[] arrNEWDate = l2.Select(x => x.date).ToArray();
                string[] arrNEWTime = l2.Select(x => x.time).ToArray();
    
                Console.WriteLine(String.Join("|", arrNEWID));
                Console.WriteLine(String.Join("|", arrNEWDate));
                Console.WriteLine(String.Join("|", arrNEWTime));
            }
    
            public class ewansObject
            {
                public string index;
                public string date;
                public string time;
                public string id;
            }
        }
    }
