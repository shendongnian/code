    callResult.ShouldBeEquivalentTo(centreResponse, opt => opt
      .Excluding(r => r.DateOpen)
      .Using<string>(ctx => CompareStrings(ctx)).WhenTypeIs<string>());
    
    
    public void CompareStrings(IAssertionContext<string> ctx)
    {
      bool equal = (string.IsNullOrEmpty(ctx.Subject) && string.IsNullOrEmpty(ctx.Expectation)) || (ctx.Subject.Equals(ctx.Expectation);
      Execute.Assertion
        .Becauseof(ctx.Reason, ctx.ReasonArgs)
        .ForCondition(equals)
        .FailWith("Expected {context:string} to be {0}{reason}, but found {1}", ctx.Subject, ctx.Expectation);
    }
