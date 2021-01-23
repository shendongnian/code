    var data = from fd in FlightDetails
               join pd in PassengersDetails on fd.Flightno equals pd.FlightNo into joinedT
               from pd in joinedT.DefaultIfEmpty()
               select new {
                             nr = fd.Flightno,
                             name = fd.FlightName,
                             passengerId = pd == null ? String.Empty : pd.PassengerId,
                             passengerType = pd == null ? String.Empty : pd.PassengerType
                           }
                        
                        
