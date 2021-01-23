    public class ExampleProfile : Profile
    {
        protected override void Configure()
        {
            ReplaceMemberName("Z", "A");
            CreateMap<Source, Destination>(); // Notice this is CreateMap, NOT Mapper.CreateMap...
        }
        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
