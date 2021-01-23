    [Fact]
    public void SepTest()
    {
        var sunday = new DateTime(2014, 8, 24);
        var expected = Enumerable.Range(0, 7).Select(d => sunday.AddDays(d));
        var week = Week.UpTo(new DateTime(2014, 9, 1));
        Assert.Equal(expected, week);
    }
    [Fact]
    public void OctTest()
    {
        var wednesday = new DateTime(2014, 10, 1);
        var expected = Enumerable.Range(0, 4).Select(d => wednesday.AddDays(d));
        var week = Week.UpTo(new DateTime(2014, 10, 6));
        Assert.Equal(expected, week);
    }
