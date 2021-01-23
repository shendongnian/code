    class Program
    {
        static void Main(string[] args)
        {
            string data = "data1=user1&data2=user2";
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:60395/Service1.asmx/HelloWorldNew");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataStream.Length;
            Stream newStream = request.GetRequestStream();            
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();
            var reader = new System.IO.StreamReader(request.GetResponse().GetResponseStream());
            string dataReturn = reader.ReadToEnd();
        }
    }  
