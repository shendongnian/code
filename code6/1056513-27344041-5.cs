    [RoutePrefix("api/Photos")]
	public class PhotosController : ApiController
		{
		[Route("Delete")]
		public void Delete(string photoid)
			{
			//code to delete photo from database
			}
		}
