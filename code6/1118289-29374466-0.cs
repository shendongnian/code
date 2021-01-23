        [TestMethod]
        public void TwoCallsDifferentIds()
        {
            int idOne = 1;
            int idTwo = 2;
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Rows.Add(idOne);
            dt.Rows.Add(idTwo);
            FakeProcessor processor = new FakeProcessor();
            Runner runner = new Runner(processor);
            runner.Process(dt);
            Assert.AreEqual(2, processor.MyArgsIds.Count);
            Assert.AreEqual(1, processor.MyArgsIds[0]);
            Assert.AreEqual(2, processor.MyArgsIds[1]);
        }
