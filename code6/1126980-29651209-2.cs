    return
        context.Reservations
            .Where(r => r.ArrivalDate >= DateNow)
            .Select(r => new
            {
                r.ReservationId,
                r.DepartureDate,
                ...//Other properties
            })
            .AsEnumerable()
            .Select(r => new Reservation
            {
                ReservationId = r.ReservationId,
                DepartureDate = r.DepartureDate,
                ...//Other properties
            })
            .ToList();
