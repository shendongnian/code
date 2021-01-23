	public static void DownloadFileInPiecesAndSave()
	{
		//test
		var uri = new Uri("http://www.w3.org/");
		var bytes = DownloadInPieces(uri, 4);
		File.WriteAllBytes(@"c:\temp\RangeDownloadSample.html", bytes);
	}
		
	/// <summary>
	/// Donwload a file via HTTP in multiple pieces using a Range request.
	/// </summary>
	public static byte[] DownloadInPieces(Uri uri, uint numberOfPieces)
	{
		//I'm just fudging this for expository purposes. In reality you would probably want to do a HEAD request to get total file size.
		ulong totalFileSize = 1003; 
		var pieceSize = totalFileSize / numberOfPieces;
		List<Task<byte[]>> tasks = new List<Task<byte[]>>();
		for (uint i = 0; i < numberOfPieces; i++)
		{
			var start = i * pieceSize;
			var end = start + (i == numberOfPieces - 1 ? pieceSize + totalFileSize % numberOfPieces : pieceSize);
			tasks.Add(DownloadFilePiece(uri, start, end));
		}
		Task.WaitAll(tasks.ToArray());
		//This is probably not the single most efficient way to combine byte arrays, but it is succinct...
		return tasks.SelectMany(t => t.Result).ToArray();
	}
	private static async Task<byte[]> DownloadFilePiece(Uri uri, ulong rangeStart, ulong rangeEnd)
	{
		try
		{
			var request = (HttpWebRequest)WebRequest.Create(uri);
			request.AddRange((long)rangeStart, (long)rangeEnd);
			request.Proxy = WebProxy.GetDefaultProxy();
			using (var response = await request.GetResponseAsync())
			using (var responseStream = response.GetResponseStream())
			using (var memoryStream = new MemoryStream((int)(rangeEnd - rangeStart)))
			{
				await responseStream.CopyToAsync(memoryStream);
				return memoryStream.ToArray();
			}
		}
		catch (WebException wex)
		{
			//Do lots of error handling here, lots of things can go wrong
			//In particular watch for 416 Requested Range Not Satisfiable
			return null;
		}
		catch (Exception ex)
		{
			//handle the unexpected here...
			return null;
		}
	}
