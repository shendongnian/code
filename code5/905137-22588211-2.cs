    cacheService
        .Stub(s => s.Get(Arg<string>.Is.Anything, Arg<Func<SomeDto>>.Is.Anything))
        .WhenCalled(m =>
            {
                var func = (Func<SomeDto>)m.Arguments[1];
                m.ReturnValue = func();
            })
        .Return(null);
