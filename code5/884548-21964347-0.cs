    class Program
    {
        static void Main(string[] args)
        {
            try{
               File.Open(@"c:\test\lock", FileMode.Open, FileAccess.Read, FileShare.None);
            
            var countryCode = "34";
            WebServiceClient client = new WebServiceClient(); //ASP.NET web service
            var output = client.Process(countryCode);//this is a time consuming process and takes 5 minutes or more
            File.WriteAllText("c:\\test\\country.txt", output);
            }
            catch(Exception e)
            {
               //you can check if there is file if already open message
               return;
           }
        }              
    }
