    cacheService
        .Stub(s => s.Get(Arg<string>.Is.Anything, Arg<Func<string>>.Is.Anything))
        .WhenCalled(m =>
            {
                var func = (Func<string>)m.Arguments[1];
                m.ReturnValue = func();
            })
        .Return(null);
