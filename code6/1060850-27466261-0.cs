    public class MediaLibraries
    {
    	private static readonly string LibrariesFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Libraries";
    	private static readonly string VideosLibraryFileName = "Videos.library-ms";
    
    	private static IEnumerable<DirectoryInfo> _videosDirectories;
    
    	public static IEnumerable<DirectoryInfo> VideosDirectories
    	{
    		get
    		{
    			if (_videosDirectories != null)
    				return _videosDirectories;
    
    			_videosDirectories = new HashSet<DirectoryInfo>();
    
    			var videosLibraryXmlFilePath = Path.Combine(LibrariesFolderPath, VideosLibraryFileName);
    
    			if (!File.Exists(videosLibraryXmlFilePath))
    				return _videosDirectories;
    
    			XDocument videosLibraryXml = XDocument.Load(File.OpenRead(videosLibraryXmlFilePath));
    			XNamespace ns = videosLibraryXml.Root.Name.Namespace;
    
    			string[] videoFoldersPaths = videosLibraryXml.Root.Element(ns + "searchConnectorDescriptionList").Elements(ns + "searchConnectorDescription")
    										 .Select(scd => scd.Element(ns + "simpleLocation").Element(ns + "url").Value).ToArray();
    
    			_videosDirectories = videoFoldersPaths.Select(v => new DirectoryInfo(v)).AsEnumerable();
    
    			return _videosDirectories;
    		}
    	}
    }
