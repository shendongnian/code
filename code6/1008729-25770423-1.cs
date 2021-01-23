    var test = new Test();
    
    var obs = Observable.FromEvent<Test.MyDelegate, Tuple<int,int>>(
        handler =>
        {
            Test.MyDelegate myDelegate = (a, b) =>
            {
                handler(Tuple.Create(a,b));
            };
            return myDelegate;
        },
        h => test.SomethingHappened += h,
        h => test.SomethingHappened -= h
    );
