    [TestMethod]
        public void InsertLines()
        {
            var test = File.ReadAllLines(@"c:\SUService.log");
            var list = new List<string>();
            for (int i = 0; i < (test.Length - 1); i++)
            {
                list.Add(test[i]);
                if (test[i].Contains("my"))
                {
                    list.Add(Environment.NewLine);
                }
            }
            File.WriteAllLines(@"c:\SUService.log", list);
        }
