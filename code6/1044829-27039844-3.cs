    private static IEnumerable ReturnChopCases()
    {
        List<int> emptyList = new List<int> { };
        yield return new CustomTestCase(3,emptyList,-1).SimpleTest();
        List<int> singleItemList = new List<int> { 1 };
        yield return new CustomTestCase(3, singleItemList, 1).SimpleTest();
        yield return new CustomTestCase(3, singleItemList, 1).SimpleTest();
    }
