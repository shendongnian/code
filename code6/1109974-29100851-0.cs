    using AutoMapper;
    using AutoMapper.Mappers;
    using System.Collections.Generic;
    public class MapperFactory<TSource,TDestination> where TSource : new() where TDestination : new()
    {
        private readonly ConfigurationStore _config;
        public MapperFactory(IEnumerable<Profile> profiles)
        {
            var platformSpecificRegistry = AutoMapper.Internal.PlatformAdapter.Resolve<IPlatformSpecificMapperRegistry>();
            platformSpecificRegistry.Initialize();
            _config = new AutoMapper.ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
            foreach (var profile in profiles)
            {
                _config.AddProfile(profile);
            }
        }
        public TDestination Map(TSource sourceItem)
        {
            using (var mappingEngine = new MappingEngine(_config))
            {
                return mappingEngine.Map<TSource, TDestination>(sourceItem);
            }             
        }
    }
