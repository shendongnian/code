    using Dapper.FluentMap;
    using Repository.DTO;
    
    namespace Repository
    {
        public class Bootstrap
        {
            public static void Map()
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new EmployeeModel.EmployeeModelMap());
                });
            }
        }
    }
