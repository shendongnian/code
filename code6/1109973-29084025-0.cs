    public class ApiTestClassToTestClassMappingProfile : Profile
    { 
        protected override void Configure()
        {
            CreateMap<ApiTestClass, TestClass>()
                .IgnoreAllNonExisting();
        }
    }
