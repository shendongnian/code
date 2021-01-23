    [Test]
    public void AssumeSingleApproach()
    {
        AutoMapper.Mapper.CreateMap<Cls1, Cls2>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Addresses.Single().Street))
            .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.Addresses.Single().HouseNumber))
            ;
        var c1 = new Cls1
        {
            Addresses = new List<Address>
            {
                new Address {Street = "foo", HouseNumber = 1},
                // new Address {Street = "bar", HouseNumber = 2}, This would cause failure
            }
        };
        var c2 = AutoMapper.Mapper.Map<Cls1, Cls2>(c1);
        Assert.AreEqual(c2.Street, "foo");
    }
