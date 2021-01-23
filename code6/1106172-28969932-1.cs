    public void AssertEquals(ReportToDownload actual, ReportToDownload expected)
    {
        Assert.That(actual.PropertyA, Is.EqualTo(expected.PropertyA));
        Assert.That(actual.PropertyB, Is.EqualTo(expected.PropertyB));
    }
