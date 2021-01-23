    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
     public class Service1 : IService1
        {
            public string Calculate(int value)
            {
                Thread.Sleep(1000);
                return value.ToString();
            }
        }
