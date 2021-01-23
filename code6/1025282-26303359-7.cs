    [TestMethod]
            public void Temp()
            {
                var tester = new Repository();
    
                var ft = tester.GetFullTime();
                var pt = tester.GetPartTime();
                 Assert.AreEqual(3, ft.Count);
                 Assert.AreEqual(4, pt.Count);
            }
