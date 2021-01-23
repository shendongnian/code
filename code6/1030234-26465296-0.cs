    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<MyMappings>();              
                });
        }
    }
     public class MyMappings : Profile
    {
        public override string ProfileName
        {
            get { return "MyMappings"; }
        }
        protected override void Configure()
        {
        ......
        }
