    public static async Task CopyFileAsync(string sourcePath, string destinationPath)
    {
    	try
    	{
    		using (Stream source = File.Open(sourcePath, FileMode.Open))
    		{
    			using (Stream destination = File.Create(destinationPath))
    			{
    				await source.CopyToAsync(destination);
    			}
    		}
    	}
    	catch (IOException io)
    	{
    		HttpContext.Current.Response.Write(io.Message); //I use this within a web app change to work for your windows app
    	}
    }
