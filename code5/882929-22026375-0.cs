	public class MyQLPreviewControllerDataSource : QLPreviewControllerDataSource { 
		
		public override int PreviewItemCount (QLPreviewController controller) {
	    	return 1;
		}
		public override QLPreviewItem GetPreviewItem (QLPreviewController controller, int index)
		{
		    string fileName = @"example.pdf";
		    var documents = NSBundle.MainBundle.BundlePath;
		    var library = Path.Combine (documents,fileName);
		    NSUrl url = NSUrl.FromFilename (library);
		    return new QlItem ("Title", url);
		}
	}
