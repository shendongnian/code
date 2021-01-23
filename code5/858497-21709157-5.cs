    public class PersonCustomMapping : ICustomMapping
    {
        const string separator = " ";
        private static IMappingEngine _MappingEngine;
        public IMappingEngine MappingEngine
        {
            get
            {
                if (_MappingEngine == null)
                {
                    var configuration = new ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
                    configuration.RecognizePrefixes("Person");
                    configuration.RecognizeDestinationPrefixes("Person");
                    configuration.CreateMap<Person, MCIACRM.Model.Combine.PersonCombined>();
                    configuration.CreateMap<MCIACRM.Model.Combine.PersonCombined, Person>();
                    _MappingEngine = new MappingEngine(configuration);
                }
                return _MappingEngine;
            }
        }
    }
