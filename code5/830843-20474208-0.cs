    public static class LinqUtils{
            public class ConsecutiveGroup<T>
            {
                public T Left { get; internal set; }
                public T Right { get; internal set; }
                public long Count { get; internal set; }
            }
    
            public static IEnumerable<ConsecutiveGroup<T>> ConsecutiveCounts<T>(this IEnumerable<T> src, Func<T, T, bool> consecutive)
            {
                ConsecutiveGroup<T> current = null;
                foreach (var s in src)
                {
                    if (current==null)
                    {
                        current = new ConsecutiveGroup<T>
                            {
                                Left = s,
                                Right = s,
                                Count = 1
                            };
                        continue;
                    }
                    
                    if(consecutive(current.Right, s))
                    {
                        current.Right = s;
                        current.Count += 1;
                        continue;
                    }
    
                    yield return current;
                    
                    current = new ConsecutiveGroup<T>
                    {
                        Left = s,
                        Right = s,
                        Count = 1
                    };
                }
                
                if (current!=null)
                {
                    yield return current;
                }
            }
    }
    
    [TestFixture]
    public static class LinqUtilsTests
    {
            [Test]
            public void TestConsecutiveCounts()
            {
                var src = new[] {1,2,3,5,7,8};
                
                var expected = new[]
                    {
                        Tuple.Create<int,long>(1, 3),
                        Tuple.Create<int,long>(5, 1),
                        Tuple.Create<int,long>(7, 2)
                    };
                
                var result = src
                    .ConsecutiveCounts((prev, current) => current == (prev + 1))
                    .Select(c=>Tuple.Create(c.Left, c.Count));
    
                Assert.IsTrue(expected.SequenceEqual(result));
            }
    }
