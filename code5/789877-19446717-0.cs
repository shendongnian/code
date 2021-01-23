    public class BillValidator
    {
        static BillValidator()
        {
            Repository = ServiceLocator.Current.GetInstance<IRepository>();
        }
        public static IRepository Repository { get; set; }
    }
