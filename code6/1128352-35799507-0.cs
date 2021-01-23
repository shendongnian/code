    using System.IO;
    using System.Linq;
    
    public static class FileNameExtensions
    {
    	public static string ToValidPath(this string path)
    	{
    		return Path.GetInvalidFileNameChars()
    			.Aggregate(path, (previous, current) => previous.Replace(current.ToString(), string.Empty));
    	}
    }
