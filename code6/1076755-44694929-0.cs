    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("REMOVED.csv");
        request.Credentials = new NetworkCredential("xyz", "*******");
        using (WebResponse response = request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    using (TextFieldParser parser = new TextFieldParser(reader))
                    {
                        parser.HasFieldsEnclosedInQuotes = true;
                        parser.Delimiters = new string[] { "," };
                        while (parser.Peek() != -1) //use Peek instead
                        {
                            Console.WriteLine(parser.ReadLine().ToString());
                        }
                    }
                }
            }
        }
