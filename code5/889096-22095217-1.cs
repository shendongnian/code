    public class ItemMap : Profile
    {
        protected override void Configure()
        {
            CreateMap<Item, Listing>().ForMember(d => d.Others, o => o.UseValue(null));
        }
    }
