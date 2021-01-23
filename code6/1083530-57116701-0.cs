csharp
[Fact]
public void SomeTest()
{
    // Do something in Arrange and Act phase to obtain a collection
    List<int> actual = ...
    // Now the important stuff in the Assert phase
    var expected = new List<int> { 42, 87, 30 };
    Assert.Equal(expected.Count, actual.Count);
    foreach (var item in expected)
        Assert.Contains(item, actual);
}
