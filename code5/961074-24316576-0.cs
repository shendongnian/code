        public static class AutoMapperInitializer {
            public static void Init() {
                // Your models maps goes here
                Mapper.CreateMap<RegisterViewModel, User>();
                Mapper.CreateMap<User, UserViewModel>().Bidirectional();
            }
            public static void Bidirectional<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) {
                Mapper.CreateMap<TDestination, TSource>();
            }
        }
