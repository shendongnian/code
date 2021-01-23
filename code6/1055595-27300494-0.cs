		static void Main(string[] args)
		{
			for (int i = 0; i < 3; i++)
			{
				using (FileStream stream = new FileStream("sample.txt", FileMode.OpenOrCreate))
				using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, false, 0x1000, true))
				using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 0x1000, true))
				{
					writer.Flush();
					Console.WriteLine("Read \"" + reader.ReadToEnd() + "\" from the file.");
				}
			}
			Console.ReadLine();
		}
