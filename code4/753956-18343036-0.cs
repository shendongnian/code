        [TestMethod]
        public void StringConcat()
        {
            var start = DateTime.Now;
            var s = string.Empty;
            for (int i = 0; i < 100000; i++)
            {
                s += "cat";
            }
            Assert.Fail((DateTime.Now - start).TotalMilliseconds.ToString()); 
        }
        [TestMethod]
        public void StringBuilder()
        {
            var start = DateTime.Now;
            var sb = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            { 
                sb.Append("cat");
            }
            Assert.Fail((DateTime.Now - start).TotalMilliseconds.ToString()); 
        }
