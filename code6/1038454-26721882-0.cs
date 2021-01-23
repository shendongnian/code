    public interface IPlatform 
	{
		...
	}
	
	public abstract class Platform : IPlatform 
	{
		public Platform(string connString , string filePath) 
		{
          ...
		}
	}
	
	
	public sealed class Platform1 : Platform
	{
		public Platform1(string connString, string filePath) : base(connString,  filePath) {}
	}
	
	
	public interface IPlatformFactory
	{
		IPlatform GetPlatform(string code, string connString, string filePath);
	}
	
	
	public class PlatformFactory : IPlatformFactory
	{
		
		public  IPlatform GetPlatform(string code, string connString, string filePath)
		{
			...
			return new Platform1(connString,  filePath);
		}
	}
