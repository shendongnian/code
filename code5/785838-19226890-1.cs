    public class IndicatiestellingFactValueResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var model = (Model.Indicatiestelling)source.Value;
            var obj = model.IndicatiestellingFacts;
            // calculate with obj
        }
    }
    Mapper.CreateMap<Model.Indicatiestelling, ClientRechtmatigheidDto>()
        .ForMember(dest => dest.HasFactBeoordelenRechtmatigheid, opt => opt.ResolveUsing<IndicatiestellingFactValueResolver<Model.Indicatiestelling>>())
        // etc
