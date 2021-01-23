    public class Service1 : IService1
    {
        public string PostJson(Stream request)
        {
            using (var reader = new StreamReader(request))
            {
                return "You posted: " + reader.ReadToEnd();
            }
        }
    }
