    static class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://www.contoso.com/");
            var relativeUrl = new Uri("~/Pages/SomePage.aspx".Replace("~",string.Empty),UriKind.Relative);
            Uri result;
            bool success = Uri.TryCreate(uri, relativeUrl,out result);
            Console.WriteLine(success);
            Console.WriteLine(result.ToString());
        }
    }
