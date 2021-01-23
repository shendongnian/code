	var query =
		Observable.Create<HashAction>(o =>
		{
			var hash = "Create Hash Somehow";
			return Observable
				.Return(new HashAction()
				{
					Action = "Add",
					Hash = hash
				})
				.Concat(
					Observable
						.Timer(TimeSpan.FromMinutes(1.0))
						.Select(x => new HashAction()
						{
							Action = "Remove",
							Hash = hash
						}))
				.Subscribe(o);
		});
	
	query.Subscribe(x =>
	{
		if (x.Action == "Add")
		{
			/* Add Hash */
		}
		if (x.Action == "Remove")
		{
			/* Remove Hash */
		}
	});
