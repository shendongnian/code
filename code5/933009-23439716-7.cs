    public ActionResult DownloadCsv()
		{
			using (MemoryStream zippedDownloadStream = new MemoryStream())
			{
				using (ZipFile zip = new ZipFile())
				{
					using (var writerMemoryStream = new MemoryStream())
					{
						using (var streamWriter = new StreamWriter(writerMemoryStream))
						{
							var writer = new CsvWriter(streamWriter);
							//your writing
							streamWriter.Flush();
						}
						zip.AddEntry("awesome file name.csv", writerMemoryStream.ToArray());
						zippedDownloadStream.Flush();
						zip.Save(zippedDownloadStream);
						return File(zippedDownloadStream.ToArray(), "application/zip", "zippedup.zip");
					}
				}
			}
		}
