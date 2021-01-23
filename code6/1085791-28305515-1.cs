    		using (var md5 = MD5.Create())
			{
				int retries = 10;
				while (retries > 0)
				{
					try
					{
						using (var stream = File.OpenRead("C:\\Test\\Uploads\\" + e.Name))
						{
							byte[] checkSum = md5.ComputeHash(stream);
							StringBuilder sb = new StringBuilder();
							for (int i = 0; i < checkSum.Length; i++)
							{
								sb.Append(checkSum[i].ToString());
							}
						}
						// All done, leave the loop
						break;
					}
					catch (FileNotFoundException e)
					{
						// Check for your specific exception here
						retries--;
						Thread.Sleep(1000);
					}
				}
				// Do some error handling if retries is 0 here
			}
