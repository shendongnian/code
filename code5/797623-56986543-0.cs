        public class SourceOneTwo
        {
            public SourceOne SourceOne { get; set; }
            public SourceTwo SourceTwo { get; set; }
        }
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<SourceOneTwo, Destination>()
                .ForMember(dest => dest.one, m => m.MapFrom(source => source.SourceOne.abc))
                .ForMember(dest => dest.two, m => m.MapFrom(source => source.SourceTwo.xyz)));
            config.AssertConfigurationIsValid();
        }
