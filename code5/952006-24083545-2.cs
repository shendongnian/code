    callResult.ShouldBeEquivalentTo(centreResponse, opt => opt
              .Excluding(r => r.DateOpen)
              .Using<string>(ctx => CompareStrings(ctx)).WhenTypeIs<string>());       
            
    public void CompareStrings(IAssertionContext<string> ctx)
    {
        var equal = (ctx.Subject ?? string.Empty).Equals(ctx.Expectation ?? string.Empty);
    
        Execute.Assertion
            .BecauseOf(ctx.Because, ctx.BecauseArgs)
            .ForCondition(equal)
            .FailWith("Expected {context:string} to be {0}{reason}, but found {1}", ctx.Subject, ctx.Expectation);
    }    
