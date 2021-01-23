    class Program
    {
        static void Main(string[] args)
        {
            var cookieCont = new CookieContainer();
            using(var svc = new TestServiceReference.TestServiceClient())
            {
                cookieCont.Add(svc.Endpoint.Address.Uri, new Cookie("TestClientCookie", "Cookie Value 123"));
                var behave = new CookieBehavior(cookieCont);
                svc.Endpoint.EndpointBehaviors.Add(behave);
                var data = svc.GetData(123);
                Console.WriteLine(data);
                Console.WriteLine("---");
                foreach (Cookie x in cookieCont.GetCookies(svc.Endpoint.Address.Uri))
                    Console.WriteLine(x.Name + "=" + x.Value);
            }
            Console.ReadLine();
        }
    }
