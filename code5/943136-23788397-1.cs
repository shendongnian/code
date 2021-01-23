    void Main()
    {
        //Change this to be the keypress/propertychagned event. The type T doesn't matter we ignore it
        var typing = Observable.Interval(TimeSpan.FromSeconds(0.25)).Take(4);
	var silence = Observable.Timer(TimeSpan.FromSeconds(1)).IgnoreElements();
	var source = typing.Concat(silence).Concat(typing);
        
        var disableSpellcheck = source.Select(_=>false);
        var enableSpellcheck = source.Select(_=>Observable.Timer(TimeSpan.FromSeconds(1)))
            .Switch()
            .Select(_=>true);
            
        Observable.Merge(disableSpellcheck, enableSpellcheck)
                .DistinctUntilChanged()
                .Subscribe(isEnabled=>SetFlag(isEnabled));
        
    }
    
    // Define other methods and classes here
    public void SetFlag(bool flag)
    {
        flag.Dump("flag");
    }
