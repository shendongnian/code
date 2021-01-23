    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = new List<object>() { new List<int>(){1} };
            var y = new List<object>() { new List<int>(){1} };
            x.SequenceRecursiveEqual(y);
            
        }
    }
    public static class ExtenderListAssert
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
                    var right = expected[i];
                    if(left is IList && right is IList)
                    {
                        (left as IList).SequenceRecursiveEqual(right as IList);
                    }
                    else
                    {
                        Assert.AreEqual(left, right);
                    }
                }
            }
        }
    }
