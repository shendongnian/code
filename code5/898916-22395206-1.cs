	var reservations = 
		EnumerableEx
			.Using(
				() => new MainContextDB(),
				db =>
					from c in db.Reservations
					select new
					{
						c.CustAcctNo, c.ReservNo, c.ReservStatus
					})
			.ToList();
