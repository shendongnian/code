        public IEnumerable<TestCaseData> combination_tests()
            {
              yield return new TestCaseData(5,1,new int[,] {{1}, {2}, {3}, {4}, {5}});
            }
        [Test]
        [TestCaseSource("combination_tests")]
        public void test(int a, int b, int[,] r)
            {
                Console.WriteLine(r[0,0] & r[1,0]);
            }
