	public HttpResponseMessage EnsureSuccessStatusCode()
		{
			if (!this.IsSuccessStatusCode)
			{
				if (this.content != null)
				{
					this.content.Dispose();
				}
				throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, SR.net_http_message_not_success_statuscode, new object[]
				{
					(int)this.statusCode,
					this.ReasonPhrase
				}));
			}
			return this;
		}
