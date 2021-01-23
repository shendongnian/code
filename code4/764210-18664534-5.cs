    public static class SurrogateServiceTest {
        public static void DefineSurrogate(ServiceEndpoint endPoint, IDataContractSurrogate surrogate) {
            foreach (var operation in endPoint.Contract.Operations) {
                var ob = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                ob.DataContractSurrogate = surrogate;
            }
        }
        public static void Start() {
            var baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            var host = new ServiceHost(typeof(SurrogateService), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(ISurrogateService), new BasicHttpBinding(), "");
            host.Open();
            var surrogate = new CustomSurrogate();
            DefineSurrogate(endpoint, surrogate);
            Console.WriteLine("Host opened");
            var factory = new ChannelFactory<ISurrogateService>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            DefineSurrogate(factory.Endpoint, surrogate);
            var client = factory.CreateChannel();
            var now = SystemClock.Instance.Now.InUtc();
            var p = client.GetParams(localDate: now.Date, localDateTime: now.LocalDateTime, zonedDateTime: now);
            if (p.Item1 == now.Date && p.Item2 == now.LocalDateTime && p.Item3 == now) {
                Console.WriteLine("Success");
            }
            else {
                Console.WriteLine("Failure");
            }
            ((IClientChannel)client).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
