    public class Cls1AndAddress
    {
        public Cls1 Cls1;
        public Address Address;
    }
    [Test]
    public void DenormalizationApproach()
    {
        AutoMapper.Mapper.CreateMap<Cls1AndAddress, Cls2>()
            .ForMember(dest => dest.Prop1, opt => opt.MapFrom(src => src.Cls1.Name))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.HouseNumber, opt => opt.MapFrom(src => src.Address.HouseNumber))
            ;
        var c1 = new Cls1
        {
            Addresses = new List<Address>
            {
                new Address {Street = "foo", HouseNumber = 1},
                new Address {Street = "bar", HouseNumber = 2},
            }
        };
        var denormalized = c1.Addresses.Select(address => new Cls1AndAddress {Cls1 = c1, Address = address});
        var c2 = AutoMapper.Mapper.Map<IEnumerable<Cls1AndAddress>, IEnumerable<Cls2>>(denormalized);
        var c2Array = c2.ToArray();
        Assert.AreEqual(2, c2Array.Length);
        Assert.AreEqual("foo", c2Array[0].Street);
        Assert.AreEqual("bar", c2Array[1].Street);
    }
