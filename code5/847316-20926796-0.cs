    public class UploadController : Controller
    {
    	[HttpPost]
    	public JsonResult FilesList(List<HttpPostedFileBase> myFiles)
        {
    		string message;
    		if (myFiles == null)
    		{
    			message = "myFiles is null";
    		}
    		else if (myFiles.Count != 2)
    		{
    			message = "myFiles.Count is " + myFiles.Count;
    		}
    		else
    		{
    			message = string.Format("myFiles[0] is {0}, myFiles[1] = {1}",
    				myFiles[0] == null ? "null" : myFiles[0].FileName,
    				myFiles[1] == null ? "null" : myFiles[1].FileName);
    		}
    
    		return Json(new
    		{
    			Message = message
    		});
        }
    }
