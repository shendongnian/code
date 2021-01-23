    [Test, Category("Integration"), TestCaseSource(typeof(MyDataSources),"PrepareTestCases", new object[] {param1})]
    public void TestRun(ResultsOfCallMyMethod testData)
    {
    // do something!
    }
    private class MyDataSources
    {
      public IEnumerable<ResultsOfCallMyMethod> PrepareTestCases(param1)
      {
        foreach (string entry in entries)
        {
            yield return callMyMethod(param1);
        }
      }
    }
