    [__DynamicallyInvokable]
        public Task<string> ReadAsStringAsync()
        {
          this.CheckDisposed();
          TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
          HttpUtilities.ContinueWithStandard(this.LoadIntoBufferAsync(), (Action<Task>) (task =>
          {
            if (HttpUtilities.HandleFaultsAndCancelation<string>(task, tcs))
              return;
            if (this.bufferedContent.Length == 0L)
            {
              tcs.TrySetResult(string.Empty);
            }
            else
            {
              Encoding encoding1 = (Encoding) null;
              int index = -1;
              byte[] buffer = this.bufferedContent.GetBuffer();
              int dataLength = (int) this.bufferedContent.Length;
              if (this.Headers.ContentType != null)
              {
                if (this.Headers.ContentType.CharSet != null)
                {
                  try
                  {
                    encoding1 = Encoding.GetEncoding(this.Headers.ContentType.CharSet);
                  }
                  catch (ArgumentException ex)
                  {
                    tcs.TrySetException((Exception) new InvalidOperationException(SR.net_http_content_invalid_charset, (Exception) ex));
                    return;
                  }
                }
              }
              if (encoding1 == null)
              {
                foreach (Encoding encoding2 in HttpContent.EncodingsWithBom)
                {
                  byte[] preamble = encoding2.GetPreamble();
                  if (HttpContent.ByteArrayHasPrefix(buffer, dataLength, preamble))
                  {
                    encoding1 = encoding2;
                    index = preamble.Length;
                    break;
                  }
                }
              }
              Encoding encoding3 = encoding1 ?? HttpContent.DefaultStringEncoding;
              if (index == -1)
              {
                byte[] preamble = encoding3.GetPreamble();
                index = !HttpContent.ByteArrayHasPrefix(buffer, dataLength, preamble) ? 0 : preamble.Length;
              }
              try
              {
                tcs.TrySetResult(encoding3.GetString(buffer, index, dataLength - index));
              }
              catch (Exception ex)
              {
                tcs.TrySetException(ex);
              }
            }
          }));
          return tcs.Task;
        }
