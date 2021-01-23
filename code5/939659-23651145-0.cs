    public class Service1 : IService1
    {
        public System.IO.Stream GetData(int value)
        {
            WebRequest wr = WebRequest.Create("//url_to_B//");
            String username = "user";
            String password = "password";
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + password));
            wr.Headers.Add("Authorization", "Basic " + encoded);
            return wr.GetResponse().GetResponseStream();
        }
    }
