    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str =
                @"{ Desc = Marketcap, Val = 1,270.10 BTC 706,709.04 USD 508,040.00 EUR 4,381,184.55 CNY 425,238.14 GBP 627,638.19 CHF 785,601.09 CAD 72,442,058.40 JPY 787,357.97 AUD 7,732,676.06 ZAR }";
            MatchCollection matches = Regex.Matches(str, @"\d[\d,\.]+\d");
            double[] values = (from Match m in matches select double.Parse(m.Value)).ToArray();
            Assert.AreEqual(10,values.Length);
            Assert.AreEqual(1270.10,values[0]);
        }
    }
