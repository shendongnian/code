    public class TestClassPMapper
            {
                public static void Configure()
                {
                    //ToDto
                    Mapper.CreateMap<TestClassPDto, TestClassPLogical>();
    
                    //ToLogical
                    Mapper.CreateMap<TestClassPLogical, TestClassPDto>();
    
                    //What I changed
                    TestClassMapper.Configure();
    
                }
            }
