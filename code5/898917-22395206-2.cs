	var reservations = new []
	{
		new { CustAcctNo = "", ReservNo = "", ReservStatus = "" }
	}.ToList();
	
	using (MainContextDB db = new MainContextDB())
    {
        reservations = (
			from c in db.Reservations
			select new
			{
				c.CustAcctNo, c.ReservNo, c.ReservStatus
			}).ToList();
    }
