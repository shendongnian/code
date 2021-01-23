	var query =
		from n in Observable.Range(0, 100)
		from r in Observable.Using(
			() => new HttpClient(),
			client =>
				Observable
					.Start(() =>
					{
						var status = GetDeviceStatus();
						return new
						{
							Response = client
								.PostAsJson<DeviceStatus>(address, status),
							Status = status,
						};
					}))
		select new
		{
			Number = n,
			r.Response,
			r.Status,
		};
