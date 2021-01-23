    public class FooContainerTypeConverter
        : ITypeConverter<FooContainer, IEnumerable<Bar>>
    {
        public IEnumerable<Bar> Convert(ResolutionContext context)
        {
            var source = context.SourceValue as FooContainer;
            
            if(source == null)
            {
                return Enumerable.Empty<Bar>();
            }
            
            // Use the existing Foo => Bar mapping
            // combined with AfterMap
            var result = Mapper.Map<IEnumerable<Foo>,
                                    IEnumerable<Bar>>(source.Foos)
                               .AfterMap(bar => bar.Id = source.Id);
            return result;
        }
    }
