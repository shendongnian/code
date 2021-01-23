        [TestMethod]
        public void LinqArraySkipFirstColumnAndLine()
        {
            var inputString = @"SkipThisLine
                                1 4 2 1 3 5
                                2 3 1 2 4 5 
                                3 4 5 3 2 1
                                4 5 1 3 4 2
                                5 3 2 4 5 1";
            char[] lineSeparator = new char[] { '\n' };
            char[] itemSeparator = new char[] { ' ' };
            var lines = inputString.Split(lineSeparator).Skip(1);
            Assert.AreEqual(5, lines.Count(), "Expect 5 rows");
            List<List<int>> matrix = new List<List<int>>();
            lines.ToList().ForEach(line => {
                int dummy = 0;
                var items = line.Trim()
                                .Split(itemSeparator,
                                       StringSplitOptions.RemoveEmptyEntries)
                                .Skip(1);
                Assert.AreEqual(5, items.Count(), "Expect 5 items each row");
                var row = items.Where(c => int.TryParse(c, out dummy))
                               .Select(w => dummy).ToList();
                matrix.Add(row);
            });
            var elements = from row in matrix
                           from cell in row
                           select cell;
            Assert.AreEqual(25, elements.Count(), "Expect 25 elements after flattening matrix");
        }
