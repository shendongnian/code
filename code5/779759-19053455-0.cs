		static void stuff2(Stream ms)
		{
			ms.Seek(0, SeekOrigin.Begin);
			using (var sr = new StreamReader(ms))
			{
				stuff3(sr.ReadToEnd());
			}
		}
