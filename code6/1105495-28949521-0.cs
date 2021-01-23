        public bool IsTimeBeforeNow(Nullable<DateTime> time)
        {
            if (time.HasValue && time.Value < DateTime.Now)
                return true;
            return false;
        }
        [TestMethod]
        public void TestIsTimeBeforeNow()
        {
            //test time.HasValue with null
            Assert.AreEqual(false, this.IsTimeBeforeNow(null));
            //test time.HasValue with true
            //and test time.Value > DateTime.Now            
            Assert.AreEqual(false, this.IsTimeBeforeNow(DateTime.Now.AddDays(1)));
            //test time.HasValue with true
            //and test time.Value < DateTime.Now
            Assert.AreEqual(true, this.IsTimeBeforeNow(DateTime.Now.AddDays(-1)));
        }
