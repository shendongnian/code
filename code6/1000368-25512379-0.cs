	private byte[] ProcessInput(HttpRequestMessage request)
	{
		List<HttpContent> parts = new List<HttpContent>();
		byte[] result;
		result = request.Content.ReadAsByteArrayAsync().Result;
		// Stupid chunked requests remove the final CRLF, which makes .Net puke on the request.
		// So add our own CRLF.
		List<byte> crlfTemp = result.ToList();
		crlfTemp.Add(0x0D);
		crlfTemp.Add(0x0A);
		result = crlfTemp.ToArray();
		// Convert stream to MIME
		using (var stream = new MemoryStream(result))
		{
			// note: StreamContent has no Content-Type set by default
			// set a suitable Content-Type for ReadAsMultipartAsync()
			var content = new StreamContent(stream);
			content.Headers.ContentType =
				System.Net.Http.Headers.MediaTypeHeaderValue.Parse(
					"multipart/related; boundary=--MIME_boundary");
			content.Headers.ContentLength = result.Length;
			bool isMPC = content.IsMimeMultipartContent();
			Task.Factory
				.StartNew(() => parts = content.ReadAsMultipartAsync().Result.Contents.ToList(),
					CancellationToken.None,
					TaskCreationOptions.LongRunning, // guarantees separate thread
					TaskScheduler.Default)
				.Wait();
		}
	}
