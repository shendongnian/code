	public class EnumerableStreamResult : FileResult
	{
		public IEnumerable<string> Enumerable
		{
			get;
			private set;
		}
		public Encoding ContentEncoding
		{
			get;
			set;
		}
		public EnumerableStreamResult(IEnumerable<string> enumerable, string contentType)
			: base(contentType)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			this.Enumerable = enumerable;
		}
		protected override void WriteFile(HttpResponseBase response)
		{
			Stream outputStream = response.OutputStream;
			if (this.ContentEncoding != null)
			{
				response.ContentEncoding = this.ContentEncoding;
			}
			if (this.Enumerable != null)
			{
				foreach (var item in Enumerable)
				{
					
					//do your stuff here
					response.Write(item);
				}
			}
		}
	}
