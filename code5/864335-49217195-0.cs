		private async Task<Stream> OpenReport(String report)
		{
			var file = _directory.GetFiles(report + ".html");
			if (file != null && file.Any())
				return file[0].OpenRead();
			else
			{
				object locker = _locker;
				try
				{
					while (locker == null || Interlocked.CompareExchange(ref _locker, null, locker) != locker)
					{
						await Task.Delay(1);
						locker = _locker;
					}
					FileInfo newFile = new FileInfo(Path.Combine(_directory.FullName, report + ".html"));
					if (!newFile.Exists) // Double check
					{
						using (var target = newFile.OpenWrite())
						{
							WebRequest request = WebRequest.Create(BuildUrl(report));
							var response = await request.GetResponseAsync();
							using (var source = response.GetResponseStream())
								source.CopyTo(target);
						}
					}
					return newFile.OpenRead();
				}
				finally
				{
					_locker = locker;
				}
			}
		}
