	var rnd = new Random((int)DateTime.Now.Ticks);
	
	var numbers =
		Observable
			.Generate(0, n => true, n => 0,
				n => rnd.NextDouble() * 99 + 2,
				n => TimeSpan.FromSeconds(1.0));
	
	var publishedNumbers = numbers.Publish();
	
	publishedNumbers
		.ObserveOnDispatcher()
        .Subscribe(s => list1.Items.Add(s.ToString("##.00")));
    publishedNumbers
		.Where(n => n < 10)
		.ObserveOnDispatcher()
        .Subscribe(s => list2.Items.Add(s.ToString("##.00")));
	
	publishedNumbers.Connect();
