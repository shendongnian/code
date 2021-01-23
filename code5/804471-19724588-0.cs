    [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var x = new List<object>() { new List<int>() };
                var y = new List<object>() { new List<int>() };
                x.SequenceRecursiveEqual(y);
                
            }
        }
    
        public static class ExtendedListAssert
        {
            public static void SequenceRecursiveEqual(this IList sourse, IList expected)
            {
                if (sourse.Count != expected.Count)
                    Assert.Fail();
                else
                {
                    for (var i = 0; i < sourse.Count; i++)
                    {
                        var left = sourse[i];
                        var right = sourse[i];
                        if(left is IList && right is IList)
                        {
                         (left as IList).SequenceRecursiveEqual(right as IList);
                        }
                        else
                        {
                            Assert.Equals(left, right);
                        }
                    }
                }
            }
        }
