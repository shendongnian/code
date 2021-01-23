		var publications = 
			obs
			.Do(x => Console.WriteLine("to buffer {0}", x), () => Console.WriteLine("to buffer complete"))
			.Buffer(2)
			.Do(x => Console.WriteLine("from buffer {0}", ShowContent(x)), () => Console.WriteLine("from buffer complete"))
			.ObserveOn(ThreadPoolScheduler.Instance)
			.Do(x => Console.WriteLine("to selectmany {0}", ShowContent(x)), () => Console.WriteLine("to selectmany complete"))
			.SelectMany(x => Test(x).ToEnumerable())
			.Do(x => Console.WriteLine("notify {0}", x), () => Console.WriteLine("complete"));
		
		publications
			.Do(x => Console.WriteLine("publications notify {0}", x), () => Console.WriteLine("publications complete"))
			.Subscribe(); /* Subscription #1 here! */
		
		obs.OnNext(1);
		obs.OnNext(2);
		obs.OnNext(3);
		
		obs.OnCompleted();
