    [Fact]
    public void RestorableRandomWorks()
    {
        RestorableRandom r = new RestorableRandom();
        double firstValueInSequence = r.Generator.NextDouble();
        int state = r.GetState();
        double secondValueInSequence = r.Generator.NextDouble();
        double thirdValueInSequence = r.Generator.NextDouble();
        r.RestoreState(state);
        r.Generator.NextDouble().Should().Be(secondValueInSequence);
        r.Generator.NextDouble().Should().Be(thirdValueInSequence);
    }
