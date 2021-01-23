            [TestMethod]
        public void TestTwiceShoot()
        {
            List<string> items = new List<string>();
            items.Add("1");
            int k = 0;
            var tasks = items.Select(d =>
            {
                k++;
                return int.Parse(d);
            });
            foreach (var r in tasks)
            {
            };
            foreach (var r in tasks)
            {
            };
            Assert.AreEqual(2, k);
        }
        [TestMethod]
        public void TestTwiceShoot2()
        {
            List<string> items = new List<string>();
            items.Add("1");
            int k = 0;
            var tasks = items.Where(d =>
            {
                k++;
                return true;
            });
            foreach (var r in tasks)
            {
            };
            foreach (var r in tasks)
            {
            };
            Assert.AreEqual(2, k);
        }
