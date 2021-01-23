    HouseDomain domainHouse = new HouseDomain
    {
        Id = 42,
        DomainRooms = new List<RoomDomain>
        {
            new RoomDomain { Name = "foo" },
            new RoomDomain { Name = "bar" }
        }
    };
    var dtoHouse = Mapper.Map<HouseDto>(domainHouse);
