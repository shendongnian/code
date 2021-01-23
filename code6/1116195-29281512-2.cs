    public static class IEnumerableAssertionExtensions
    {
        public static void ShouldContainInWrongOrder<TSubject>(this IEnumerable<TSubject> source, IEnumerable<TSubject> expected)
        {
            var remaining = expected.ToList();
            var inOrder = true;
            foreach (var subject in source)
            {
                if (inOrder && !ReferenceEquals(subject, remaining[0]))
                {
                    inOrder = false;
                }
                var s = subject;
                Execute.Verification.ForCondition(() => remaining.Remove(s)).FailWith("Expected item in the collection: {0}", subject.ToString());
            }
    
            Execute.Verification.ForCondition(() => remaining.Count == 0).FailWith(string.Format("{0} more item{1} than expected found in the list.", remaining.Count, ((remaining.Count == 1) ? string.Empty : "s")));
            Execute.Verification.ForCondition(() => !inOrder).FailWith("list items are ordered identically");
        }
    }
    
    [TestClass]
    public class TestFoo
    {
        class Thing
        {
            public int i;
        }
    
        [TestMethod]
        public void MyMethod()
        {
            var a1 = new Thing { i=0 };
            var a2 = new Thing { i=1 };
            var a3 = new Thing { i=2 };
            var a4 = new Thing { i=2 };
            var list1 = new List<Thing> { a1, a2, a3 };
            var list2 = new List<Thing> { a1, a2, a3 };
            var list3 = new List<Thing> { a3, a2, a1 };
            var list4 = new List<Thing> { a1, a2, a3, a4 };
            var list5 = new List<Thing> { a3, a2 };
    
            list1.ShouldContainInWrongOrder(list3); // Succeeds
            list1.ShouldContainInWrongOrder(list2); // Fails
            list1.ShouldContainInWrongOrder(list4); // Fails
            list1.ShouldContainInWrongOrder(list5); // Fails
        }
    }
