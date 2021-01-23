    public class IndicatiestellingFactValueResolver<TSource> : IValueResolver
    {
        private Func<TSource, object> selector;
        public IndicatiestellingFactValueResolver(Func<TSource, object> selector)
        {
            this.selector = selector;
        }
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var model = (TSource)source.Value;
            object obj = selector(model);
            // calculate with obj
        }
    }
    Mapper.CreateMap<Model.Indicatiestelling, ClientRechtmatigheidDto>()
        .ForMember(dest => dest.HasFactBeoordelenRechtmatigheid,
        opt => opt.ResolveUsing<IndicatiestellingFactValueResolver<Model.Indicatiestelling>>()
                    .ConstructedBy(() => new IndicatiestellingFactValueResolver<Model.Indicatiestelling>(x => x.IndicatiestellingFacts)))
        // etc
