    [When(@"you add the sum of (.*)")]
    public void WhenYouAddTheSumOf(int[] p1)
    {
        ScenarioContext.Current.Pending();
    }
    [StepArgumentTransformation(@"(\d+(?:,\d+)*)")]
    public int[] IntArray(string intCsv)
    {
        return intCsv.Split(',').Select(int.Parse).ToArray();
    }
