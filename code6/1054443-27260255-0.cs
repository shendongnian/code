        public class ClassToTest
    {
        internal virtual MoDataContext CreateContext()
        {
            return new MoDataContext();
        }
        public List<ViewCountryInfo> GetAllCountries()
        {
            List<ViewCountryInfo> oReturn = null;
            try
            {
                var oResult = from c in this.CreateContext().ViewCountryInfos
                              select c;
                oReturn = oResult.ToList();
            }
            catch (Exception)
            {
            }
            return oReturn;
        }
        [Fact]
        public void Test_GetAllCountries_ResultCountShouldBeGreaterThan0()
        {
            var fakeData = new List<ViewCountryInfo>();
            fakeData.Add(new ViewCountryInfo());
            var sut = A.Fake<ClassToTest>();
            A.CallTo(sut).CallsBaseMethod();
            A.CallTo(() => sut.CreateContext()).Returns(fakeData);
            var result = sut.GetAllCountries();
            Assert.IsTrue(result.Count() > 0);
        }
