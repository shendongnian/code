    using System.Data.Entity;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    
    namespace EFMock
    {
        internal interface IDataContext
        {
            IDbSet<DataItem> DataItems { get; set; }
        }
    
        class DataContext : DbContext, IDataContext
        {
            public IDbSet<DataItem> DataItems{ get; set; }
        }
    
        class DataItem
        {
            public int SomeNumber { get; set; }
            public string SomeString { get; set; }
        }
    
        /* ----------- */
    
        class DataUsage
        {
            public int DoSomething(IDataContext dataContext)
            {
                return dataContext.DataItems.Sum(x => x.SomeNumber);
            }
        }
    
        /* ----------- */
    
        [TestFixture]
        class TestClass
        {
            [Test]
            public void SomeTest()
            {
                var fakeDataItems = new [] {
                    new DataItem { SomeNumber = 1, SomeString = "One" },
                    new DataItem { SomeNumber = 2, SomeString = "Two" }};
    
                var mockDataContext = new Mock<IDataContext>();
                mockDataContext.SetupGet(x => x.DataItems).Returns(new FakeDbSet<DataItem>(fakeDataItems));
    
                var dataUsage = new DataUsage();
                var result = dataUsage.DoSomething(mockDataContext.Object);
    
                Assert.AreEqual(2, result);
            }
        }
    }
