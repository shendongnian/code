    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:60395/Service1.asmx/HelloWorld");
            request.Method = "POST";
            var reader = new System.IO.StreamReader(request.GetResponse().GetResponseStream());
            string data = reader.ReadToEnd();
        }
    }
