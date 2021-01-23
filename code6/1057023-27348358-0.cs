	class Program
	{
		static void Main(string[] args)
		{
			var myUri = new Uri("ftp://ftp.newsxpressmedia.com/Images/CB 967x330.jpg");
			var modifiedUri = new Uri(string.Format( "{0}//{1}"  
                                                    , myUri.Scheme  
                                                    , (myUri.Host + myUri.LocalPath).Replace("/", "//")
                                                    ));
			Console.ReadKey();
        }
    }
