        [TestMethod]
        public bool TestMetho()
        {
             var SY = calc.GetUserInfo(new DateTime(2015, 12, 15));
             bool isOK = Assert.AreEqual(new DateTime(2015, 11, 29), SY);
             Debug.WriteLine("Date Time : {0}", SY)
             return bool;
        }
