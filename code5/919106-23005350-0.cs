    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader rs = new StreamReader(fs))
					{
						string allText = rs.ReadToEnd();
					}
				}
