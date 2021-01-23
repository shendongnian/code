    // reservations is List<'a>.
    var reservations = this.InvokeAndReturn(() =>
    {
        using (var db = new MainContextDB())
        {
            return db.Reservations
                .Select(c => new { c.CustAcctNo, c.ReservNo, c.ReservStatus })
                .ToList();
        }
    });
