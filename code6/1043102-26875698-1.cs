        [TestMethod]
        public void tenEqualten()
        {
            Int64 a = 10;
            UInt32 b = 10;
            object c = a;
            object d = b;
            Assert.AreEqual(c, d);
        }
