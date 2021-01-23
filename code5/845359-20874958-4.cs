            foreach (var row in query)
            {
                friends.Add(new FriendModel()
                {
                    Id = row.Friends.Id,
                    FirstName = row.Friends.FirstName,
                    LastName = row.Friends.LastName,
                    PhoneNumber = row.Friends.PhoneNumber,
                    UserId = row.Friends.Id,
                    Carriers = new List<CarriersModel>()
                    {
                        new CarriersModel(){
                            CarrierName = row.Carrier.CarrierName,
                            CarrierEmail = row.Carrier.CarrierEmail,
                        }
                    }
                });
            }
