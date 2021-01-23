    class Program {
        static void Main(string[] args) {
            var firstArray = new object[][] { new object[] { 1, "A", false },
                                              new object[] { 2, "B", false },
                                              new object[] { 3, "C", false },
                                              new object[] { 4, "D", true },
                                              new object[] { 5, "E", true }
                                           };
            var secondArray = new object[] { 6, 7 };
            var joiner = new Joiner();
            IEnumerable<IEnumerable<object>> result = joiner.Join(firstArray.ToList(), secondArray.ToList());
            //result = new object[] { new object[] { 6, 1, "A", false },
            //                        new object[] { 7, 1, "A", false },
            //                        new object[] { 6, 2, "B", false },
            //                        new object[] { 7, 2, "B", false },
            //                        new object[] { 6, 3, "C", false },
            //                        new object[] { 7, 3, "C", false },
            //                        new object[] { 6, 4, "D", true },
            //                        new object[] { 7, 4, "D", true },
            //                        new object[] { 6, 5, "E", true },
            //                        new object[] { 7, 5, "E", true }
            //                      };
        }
    }
    public class Joiner
    {
        public IEnumerable<IEnumerable<object>> Join(IEnumerable<IEnumerable<object>> source1, IEnumerable<object> source2) {
            foreach (IEnumerable<object> s1 in source1) {
                foreach (object s2 in source2) {
                    yield return (new[] { s2 }).Concat(s1).ToArray();
                }
            }
        }
    }
