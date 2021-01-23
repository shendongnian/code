		public static void Main(string[] args)
		{
			var req = WebRequest.Create("http://www.google.com");
			req.Method = "GET";
			req.Timeout = 5000;
			using (var response = req.GetResponse())
			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				char[] buffer = new char[1024];
				int read = 0;
				int i = 0;
				do
				{
					read = reader.Read(buffer, 0, buffer.Length);
					Console.WriteLine("{0}: Read {1} bytes", i++, read);
					Console.WriteLine("'{0}'", new String(buffer, 0, read));
					Console.WriteLine();
				} while(!reader.EndOfStream);
			}
		}
