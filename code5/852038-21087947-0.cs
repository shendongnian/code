    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    namespace FluentConfigHelper.Test
    {
        [TestFixture]
        public class StackOverflowTest
        {
            private IDateHelper _dateHelper;
    
            public interface IDateHelper
            {
                DateTime Now { get; }
            }
    
            public class DateHelper : IDateHelper
            {
                public DateTime Now { get; set; }
            }
    
            public IDateHelper DateHelperLocal
            {
                get { return _dateHelper ?? (_dateHelper = new DateHelper()); }
                set { _dateHelper = value; }
            }
    
            public DateTime MethodUnderTest()
            {
                return DateHelperLocal.Now.AddMonths(1);
            }
    
            [Test]
            public void DateTimeTest()
            {
                IDateHelper dateHelper = MockRepository.GenerateStrictMock<IDateHelper>();
                DateTime now = new DateTime(2011, 12, 16);
                dateHelper.Expect(x => x.Now).Return(now);
                DateHelperLocal = dateHelper;
                var result = MethodUnderTest();
                Assert.AreEqual(new DateTime(2012, 1, 16), result);
                dateHelper.VerifyAllExpectations();
            }
        }
    }
