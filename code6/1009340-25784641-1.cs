    int something = GetNumber();
    bool possible = GetPossibility();
    var somethingIsPositive = new Lazy<bool>(() => something > 0);
    var itIsImpossible = new Lazy<bool>(() => !possible);
    if( somethingIsPositive.Value && itIsImpossible.Value){
           doSomething();
    }
