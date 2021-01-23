        [TestMethod]
        public void TestMethod1()
        {
            List<int> values = new List<int>{15, 13, 14, 9, 10, 11, 12, 1, 2, 3, 4, 5, 6, 7, 8};
            Assert.AreEqual(values.IndexOf(13) + 1, Stuff.GetParent(values.IndexOf(9) + 1));
            Assert.AreEqual(values.IndexOf(13) + 1, Stuff.GetParent(values.IndexOf(10) + 1));
            Assert.AreEqual(values.IndexOf(10) + 1, Stuff.GetParent(values.IndexOf(4) + 1));
            Assert.AreEqual(null, Stuff.GetParent(values.IndexOf(15)));
        }
