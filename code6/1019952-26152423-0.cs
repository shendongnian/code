`[Test]
public void Sum_Is_Zero_When_No_Entries()
{
    var bomManager = new BomManager();
    Assert.AreEqual(0, bomManager.MethodToTest(new Collection<int>()));
}
`
and then write the following code (note: we write the minimum to meet the current set of tests)
`public int MethodToTest(Collection<int> collection)
{
    var sum = 0;
    return sum;
}
`
We would then write a new test e.g.
`[Test]
[TestCase(new[] { 0 }, 0)]
public void Sum_Is_Calculated_Correctly_When_Entries_Supplied(int[] data, int expected)
{
    var bomManager = new BomManager();
    Assert.AreEqual(expected, bomManager.MethodToTest(new Collection<int>(data)));
}
`
If we ran our tests they would all pass (green) so we need a new test(cases)
`[TestCase(new[] { 1 }, 1)]
[TestCase(new[] { 1, 2, 3 }, 6)]
`
In order to satisfy those tests I would need to modify my code e.g.
`public int MethodToTest(Collection<int> collection)
{
    var sum = 0;
    foreach (var value in collection)
    {
        sum += value;
    }
    return sum;
}
`
Now all my tests work and if I run that through opencover I get 100% sequence and branch coverage - Hurrah!.... And I did so without using coverage as my control but writing the right tests to support my code.
BUT there is a 'possible' defect... what if I pass in `null`? Time for a new test to investigate
`[Test]
public void Sum_Is_Zero_When_Null_Collection()
{
    var bomManager = new BomManager();
    Assert.AreEqual(0, bomManager.MethodToTest(null));
}
`
The test fails so we need to update our code e.g.
`public int MethodToTest(Collection<int> collection)
{
    var sum = 0;
    if (collection != null)
    {
        foreach (var value in collection)
        {
            sum += value;
        }
    }
    return sum;
}
`
Now we have tests that support our code rather than tests that test our code i.e. our tests do not care about how we went about writing our code.
Now we have a good set of tests so we can now safely refactor our code e.g.
`public int MethodToTest(IEnumerable<int> collection)
{
    return (collection ?? new int[0]).Sum();
}
`
And I did so without affecting any of the existing tests.
I hope this helps.
