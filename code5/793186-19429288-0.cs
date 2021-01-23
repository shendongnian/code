    [ErrorBehavior(typeof(ErrorHandler))]
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, InstanceContextMode=InstanceContextMode.PerCall)]
    public class EmailRepository : IEmailRepository
    {
        private static object _lockOb = new object();
        public string GetEmail(Guid IdUser)
        {
            lock(_lockOb)
            {
                //Logic to retrive one email based on data of receive
            }
        }
    }
