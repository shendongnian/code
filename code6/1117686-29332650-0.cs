    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    namespace SupportSrvWCF
    {
        [ServiceContract]
        public interface IA
        {
            [OperationContract]
            int LogIt(int id, string data, ref int level);
        }
        public class SupportServicee : IA
        {
            public int LogIt(int id, string data, ref int level)
            {
                return 0;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                using (ServiceHost selfHost = new ServiceHost(typeof(SupportServicee),new Uri("http://localhost:8080/Myservice"))) 
                {
                    try
                    {
                        selfHost.AddServiceEndpoint(typeof(IA),new BasicHttpBinding(),"basic");
                        selfHost.Open();
                        Console.WriteLine("The service is running. Press any key to stop.");
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: '{0}'", e);
                    }
                }
            }
        }
    }
