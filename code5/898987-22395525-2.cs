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
            }).ToList();
            foreach (var r in tasks)
            {
            };
            foreach (var r in tasks)
            {
            };
            Assert.AreEqual(1, k);
        }
