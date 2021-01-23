    interface IUnitOfMeasurementFactory
    {
        T Create<T>(string name, double value) where T: UnitOfMeasurement;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<DistanceUnitOfMeasurementFactory>().ToFactory();
            var factory = kernel.Get<IUnitOfMeasurementFactory>();
            var meters = factory.Create<Meters>("myDistance", 123.12);
            var knots = factory.Create<Knots>("mySpeed", 345.21)
        }
    }
