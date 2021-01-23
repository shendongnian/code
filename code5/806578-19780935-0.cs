    using Raven.Client.Indexes;
    using Raven.Tests.Helpers;
    using System;
    using System.Linq;
    using Xunit; //XUnit
    //using Microsoft.VisualStudio.TestTools.UnitTesting; //MSTest
    namespace RavenDBTest.Tests
    {
        //[TestClass] //MSTest
        public class RavenIndexTest : RavenTestBase
        {
            //[TestMethod] //MSTest
            [Fact] //XUnit
            public void CanIndexAndQuery()
            {
                var timestamp = DateTime.Now;
                var report1 = new Entity { CategoryId = 123, Price = 51, Timestamp = timestamp.AddSeconds(-20) };
                var report2 = new Entity { CategoryId = 123, Price = 62, Timestamp = timestamp.AddSeconds(-10) };
                var report3 = new Entity { CategoryId = 123, Price = 73, Timestamp = timestamp };
            
                using (var store = NewDocumentStore())
                {
                    new LatestEntity_Index().Execute(store);
                    using (var session = store.OpenSession())
                    {
                        session.Store(report1);
                        session.Store(report2);
                        session.Store(report3);
                        session.SaveChanges();
                    }
                    //WILL PASS
                    using (var session = store.OpenSession())
                    {
                        var result = session.Query<LastEntity, LatestEntity_Index>()
                            .Customize(customization => customization.WaitForNonStaleResultsAsOfNow())
                            .FirstOrDefault()
                            .LastReport;
                        AssertLatestResult(timestamp, result);
                    }
                    //WILL FAIL
                    using (var session = store.OpenSession())
                    {
                        var result = session.Query<LastEntity, LatestEntity_Index>()
                            .Customize(customization => customization.WaitForNonStaleResultsAsOfNow())
                            .Select(a => a.LastReport)
                            .FirstOrDefault();
                        AssertLatestResult(timestamp, result);
                    }
                }
            }
            private static void AssertLatestResult(DateTime timestamp, Entity result)
            {
                //MSTest:
                //Assert.AreEqual(123, result.CategoryId, "Category Does Not Match");
                //Assert.AreEqual(73, result.Price, "Latest Price Does Not Match");
                //Assert.AreEqual(timestamp, result.Timestamp, "Latest Timestamp Does Not Match");
                //XUnit:
                Assert.Equal(123, result.CategoryId);
                Assert.Equal(73, result.Price);
                Assert.Equal(timestamp, result.Timestamp);
            }
        }
        public class Entity
        {
            public int CategoryId {get;set;} //Unique identifier for the category the price applies to.
            public int Price {get;set;} //Changes with time
            public DateTime Timestamp {get;set;} //DateTime.UtcNow
        }
        public class LastEntity
        {
            public int CategoryId { get; set; }
            public DateTime Timestamp { get; set; }
            public Entity LastReport { get; set; }
        }
        public class LatestEntity_Index : AbstractIndexCreationTask<Entity, LastEntity>
        {
            public LatestEntity_Index()
            {
                Map = reports => from report in reports
                                 select new LastEntity
                                 {
                                     CategoryId = report.CategoryId,
                                     Timestamp = report.Timestamp,
                                     LastReport = report,
                                 };
                Reduce = reports => from report in reports
                                    group report by report.CategoryId
                                        into g
                                        let last = g.OrderBy(a=>a.Timestamp).Last()
                                        select new LastEntity
                                        {
                                            CategoryId = g.Key,
                                            Timestamp = last.Timestamp,
                                            LastReport = last.LastReport,
                                        };
            }
        }
    }
