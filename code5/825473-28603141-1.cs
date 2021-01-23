chsarp
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
public class UploadController : ApiController
{
	public async Task<HttpResponseMessage> PostFormData()
	{
		// Check if the request contains multipart/form-data.
		if (!Request.Content.IsMimeMultipartContent())
		{
			throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
		}
		string root = HttpContext.Current.Server.MapPath("~/App_Data");
		var provider = new MultipartFormDataStreamProvider(root);
		try
		{
			// Read the form data.
			await Request.Content.ReadAsMultipartAsync(provider);
			// This illustrates how to get the file names.
			foreach (MultipartFileData file in provider.FileData)
			{
				Trace.WriteLine(file.Headers.ContentDisposition.FileName);
				Trace.WriteLine("Server file path: " + file.LocalFileName);
			}
			
			return Request.CreateResponse(HttpStatusCode.OK);
		}
		catch (System.Exception e)
		{
			return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
		}
	}
}
Here's where I found it:
http://www.asp.net/web-api/overview/advanced/sending-html-form-data,-part-2
For a more Elaborate implementation:
http://galratner.com/blogs/net/archive/2013/03/22/using-html-5-and-the-web-api-for-ajax-file-uploads-with-image-preview-and-a-progress-bar.aspx
