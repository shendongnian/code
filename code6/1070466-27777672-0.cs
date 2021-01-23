    public class DocumentHandler : IHttpHandler {
		public Boolean IsReusable {
			get { return true; }
		}
		public void ProcessRequest(HttpContext context) {
			// TODO: Get URL of the document somehow for the REST request
			// context.Request
			// TODO: Make request to REST service
			// Some pseudo-code for you:
			context.Response.ContentType = "application/pdf";
			Byte[] buffer = new WebClient().DownloadData(url);
			context.Response.OutputStream.Write(buffer, 0, buffer.Length);
			context.Response.End();
		}
	}
