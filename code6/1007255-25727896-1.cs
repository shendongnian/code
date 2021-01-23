    /// <summary>
    /// Simple controller that the users will connect to.
    /// It does not even have a method in this sample...
    /// 
    /// The ImageWatcher class will send images to the clients when you drop a imagein c:\temp\image
    /// </summary>
    [XSocketMetadata(PluginAlias = "image")]
    public class ImageController : XSocketController
    {
        
    }
