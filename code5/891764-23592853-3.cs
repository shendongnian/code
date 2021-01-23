    [Theory]
    [PropertyAutoData("ColorPairs")]
    public void ReverseColors([TestCaseParameter] TestData testData, int autoGenValue) { ... }
    public static IEnumerable<object[]> ColorPairs
    {
      get
      {
        yield return new object[] { new TestData { Input = Color.Black, Expected = Color.White } };
        yield return new object[] { new TestData { Input = Color.White, Expected = Color.Black } };
      }
    }
