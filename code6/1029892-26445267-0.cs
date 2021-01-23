    [HttpPost]
    public string UploadVideo(HttpFileCollection video)
    {
    	if (video.Count <= 0) return null;
    	var fileName = Path.GetFileName(video.Get(0).FileName);
    	var path = Path.Combine(Server.MapPath("~/Content/Videos"), fileName);
    	// save video here
    	return fileName;
    }
    [ValidateInput(false)]
    public ActionResult Update(int? id, string title, string body, DateTime dateTime, string tags)
    {
    	if (!IsAdmin)
    	{
    		return RedirectToAction("Index");
    	}
    
    	var post = GetPost(id); // get the post object
    
    	var video = System.Web.HttpContext.Current.Request.Files;
    
    	post.Title = title;
    	post.Body = body;
    	post.DateTime = dateTime;
    	post.Tags.Clear();
    	post.VideoFileName = UploadVideo(video);
        // continued, more code
    }
    public class Video
    {
        public HttpFileCollection File { get; set; }
    }
