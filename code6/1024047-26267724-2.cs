    public static class ByConventionMapBuilder
    {
        public static Func<IEnumerable<Type>> DestinationTypesProvider = DefaultDestTypesProvider;
        public static Func<IEnumerable<Type>> SourceTypesProvider = DefaultSourceTypesProvider;
        public static Func<Type, Type, bool> TypeMatcher = DefaultTypeMatcher;
        public static Mapper Build()
        {
            var mapper = new Mapper();
            var sourceTypes = SourceTypesProvider().ToList();
            var destTypes = DestinationTypesProvider();
            foreach (var destCandidateType in destTypes)
            {
                var match = sourceTypes.FirstOrDefault(t => TypeMatcher(t, destCandidateType));
                if (match != null)
                {
                    mapper.CreateMap(destCandidateType, match);
                    sourceTypes.Remove(match);
                }
            }
            return mapper;
        }
        public static IEnumerable<Type> TypesFromAssembliesWhere(Func<IEnumerable<Assembly>> assembliesProvider, Predicate<Type> matches)
        {
            foreach (var a in assembliesProvider())
            {
                foreach (var t in a.GetTypes())
                {
                    if (matches(t))
                        yield return t;
                }
            }
        }
        private static IEnumerable<Type> DefaultDestTypesProvider()
        {
            return TypesFromAssembliesWhere(
                () => new[] { Assembly.GetExecutingAssembly() }, 
                t => t.IsClass && !t.IsAbstract && !t.Name.EndsWith("DTO"));
        }
        private static IEnumerable<Type> DefaultSourceTypesProvider()
        {
            return TypesFromAssembliesWhere(
                () => new[] { Assembly.GetExecutingAssembly() }, 
                t => typeof(HalResource).IsAssignableFrom(t) && !t.IsAbstract && t.Name.EndsWith("DTO"));
        }
        private static bool DefaultTypeMatcher(Type srcType, Type destType)
        {
            var stn = srcType.Name;
            return (stn.Length > 3 && stn.EndsWith("DTO") && destType.Name.EndsWith(stn.Substring(0, stn.Length - 3)));
        }
    }
    class Program
    {
        public static void Main(params string[] args)
        {
            // Configure mapper by type scanning & convention matching
            var mapper = ByConventionMapBuilder.Build();
            var myDTO = new FooDTO 
            { 
                X = 10, 
                Embedded = new FooDTO.EmbeddedDTO { Y = 5, Z = 9 } 
            };
            var mappedFoo = mapper.Map<MyMappedFoo, FooDTO>(myDTO);
            Console.WriteLine("X = {0}, Y = {1}, Z = {2}", mappedFoo.X, mappedFoo.Y, mappedFoo.Z);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
