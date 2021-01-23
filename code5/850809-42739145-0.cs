    <!-- language: c# -->
    if (response.Content.Headers.ContentDisposition == null)
    {
      IEnumerable<string> contentDisposition;
      if (response.Content.Headers.TryGetValues("Content-Disposition", out contentDisposition))
      {
       response.Content.Headers.ContentDisposition = ContentDispositionHeaderValue.Parse(contentDisposition.ToArray()[0].TrimEnd(';').Replace("\"",""));
      }
    }
