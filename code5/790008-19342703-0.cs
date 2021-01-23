    public class ImageUploader
    {
    	....
    
    	public Task<string> Upload()
    	{
    		return Task.Run(() =>
    		{
    			....
    
    			return UploadedFilePath;
    		});
    	}
    	....
    }
