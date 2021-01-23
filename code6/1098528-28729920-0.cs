    var tcs = new TaskCompletionSource<Unit>();
    
	var nextpub = publications
		.Do(x => Console.WriteLine("publications notify {0}", x),
            () => Console.WriteLine("publications complete"))
        .Subscribe(_ => {}, () => tcs.SetResult(Unit.Default));
