    public static class EnumerableAssert
    {
        public static void AreEquivilent<TExpected, TActual>(IEnumerable<TExpected> expected, IEnumerable<TActual> actual, Func<TExpected, TActual, bool> predicate)
        {
            if (ReferenceEquals(expected, actual))
            {
                return;
            }
            using (var expectedEnumerator = expected.GetEnumerator())
            using (var actualEnumerator = actual.GetEnumerator())
            {
                while (true)
                {
                    var expectedMoved = expectedEnumerator.MoveNext();
                    if (expectedMoved != actualEnumerator.MoveNext())
                    {
                        Assert.Fail("Expected and Actual collections are of different size");
                    }
                    if (!expectedMoved)
                    {
                        return;
                    }
                    Assert.IsTrue(predicate(expectedEnumerator.Current, actualEnumerator.Current));
                }
            }
        }
    }
