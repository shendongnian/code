		private const int MAX_RETRIES = 100;
		private const int MAX_RETRY_SECONDS = 120;
		public static bool IsFileReady(String sFilename)
		{
			int tryNumber = 0;
			DateTime endTime = DateTime.Now + new TimeSpan(0, 0, MAX_RETRY_SECONDS);
			while (tryNumber < MAX_RETRIES && DateTime.Now < endTime)
			{
				try
				{
					using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
					{
						if (inputStream.Length > 0)
						{
							return true;
						}
					}
				}
				catch (Exception)
				{
					//Swallow Exception
				}
				
				//Slow down the looping 
				System.Threading.Thread.Sleep(500);
				
				tryNumber += 1;
			}
			return false;
		}
