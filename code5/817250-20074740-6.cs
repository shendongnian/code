    var house = this.Data.Houses.All()                
        .Where(u => u.UserId == userId && u.Name == houseName).ToList();
    var houseViewModel = house.Select(h => new HouseViewModel
        {                   
            Id = h.Id,
            Name = h.Name,
            ImageUrl = h.ImageUrl,                   
            FloorsViewModel = h.Floоrs.Where(f=>f.Id>0) 
            .Select(f => new FloorViewModel
            {
                Name = f.Name,
                RoomViewModel = f.Rooms.Where(r => r.Id > 0) 
                .Select(r => new RoomViewModel
                {
                    Id = r.Id,
                    Name = r.Name,                           
                    SensorViewModel =r.Sensor == null ? null : new SensorViewModel
                    {
                        Id = r.Sensor.Id,
                        CurrentTemp = r.Sensor.CurrentTemp,
    
                    },                           
                })
            })
        })
       .SingleOrDefault();
