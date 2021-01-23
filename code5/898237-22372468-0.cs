		static void Main()
		{
			try
			{
				StreamReader myStreamReader = null;
				try
				{
					myStreamReader = new StreamReader("c:\\genneric.txt");
					Console.WriteLine(myStreamReader.ReadToEnd());
				}
				catch (FileNotFoundException Error)
				{
					Console.WriteLine(Error.Message);
					Console.WriteLine();
					throw new Exception();
				}
				catch (Exception Error)
				{
					Console.WriteLine(Error.Message);
					Console.WriteLine();
				}
				finally
				{
					if (myStreamReader != null)
					{
						myStreamReader.Close();
					}
					Console.WriteLine("Closed the StreamReader.");
				}
			}
			catch
			{
				
			}
			Console.WriteLine("Done");
			Console.ReadLine();
		}
