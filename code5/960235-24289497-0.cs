        var filteredHotels = resp.Hotels.Select(h =>
                                h.Rooms.Select(r =>
                                r.RoomTypes.Select(rt =>
                                new
                                {
                                    HotelName = h.Name,
                                    RoomName = r.Name,
                                    RoomTypeName = rt.Name,
                                    MinPrice = rt.Prices.Min(p => p.TotalPrice)
                                })));
