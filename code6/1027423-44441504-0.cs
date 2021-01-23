    private static IEnumerable TestData()
    {
        TestCaseData data;
        data = new TestCaseData(new Foo("aaa"))
                                .SetName("case 1 {m}");
        yield return data;
        data = new TestCaseData(new Foo("bbb"));
        yield return data;
    }
