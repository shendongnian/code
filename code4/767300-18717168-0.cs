    var setups =
        bookedRooms.GroupBy(x => Tuple.Create(x.TimePeriodId, x.VenueId))
                   .SelectMany(x => x.Aggregate(
                                        new List<EventSetup>(), AccumulateRooms))
                   .OrderBy(x => x.StartDate)
                   .ToList();
    List<EventSetup> AccumulateRooms(List<EventSetup> existingSetups,
                                     BookedRoom currentRoom)
    {
        var setup = existingSetups.LastOrDefault();
        if(setup == null || setup.EndDate.AddDays(1) != currentRoom.Day.Date)
        {
            setup = new EventSetup
            {
                VenueId = currentRoom.VenueId,
                TimePeriodId = currentRoom.TimePeriodId,
                StartDate = currentRoom.Day.Date,
            };
            existingSetups.Add(setup);
        }
        setup.EndDate = currentRoom.Day.Date;
        return existingSetups;
    }
