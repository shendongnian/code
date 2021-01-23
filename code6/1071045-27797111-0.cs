    public class IncludeConfiguratorFactory
        {
            public static IConfigurator Get<T>(T type)
            {
                switch (type.Name)
                {
                    case "Vehicle":
                        return new VehicleConfigurator();
                }
            }
        }
        public class VehicleConfigurator : IConfigurator
        {
            #region IConfigurator Members
            public void Configure<T>(IQueryable<T> items ) where T : Vehicle
            {
                var vehicle = items.Include(x => x.VehicleBrand);
                vehicle = items.Include(x => x.VehicleModel);
            }
            #endregion
        }
        public interface IConfigurator
        {
            void Configure<T>(IQueryable<T> items);
        }
