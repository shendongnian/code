    public class TestClassMapper
            {
                public static void Configure()
                {
                    //ToDto
                    Mapper.CreateMap<TestClassDto, TestClassPLogical>();
    
                    //ToLogical
                    Mapper.CreateMap<TestClassLogical, TestClassDto>();
                }
            }
