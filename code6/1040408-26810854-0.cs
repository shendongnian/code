    Dictionary<string, string> versions = new Dictionary<string, string>();
    
    //Define the versions to generate
    versions.Add("_Raw", ""); //Original Image
    versions.Add("_1000x1000", "width=1000&height=1000&crop=auto"); //Fit to 1000x1000 area
    versions.Add("_500x500", "width=500&height=500&crop=auto"); //Fit to 500x500 area
    
    string[] path2 = Directory.GetFiles(@"C:\myPictures\TestImages");
    //Generate each version
    foreach (string dirFile in path2)
    {
    	foreach (string suffix in versions.Keys)
    	{
    		//Create directory/path based on file type (ex. _Raw, _1000, etc.)
    		string uploadFolder = MapPath("~/TestImages/" + suffix.Replace("_", ""));
    
    		//Get the physical path for the uploads folder and make sure it exists
    		if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);
    
    		////Generate a filename.
    		string filePath = Path.GetFileName(dirFile);
    		string fileName = Path.Combine(uploadFolder, filePath + suffix);
    
    		//Let the image builder add the correct extension based on the output file type
    		fileName = ImageBuilder.Current.Build(new ImageJob(dirFile, fileName, new Instructions(versions[suffix]), false, true)).FinalPath;
    	}
    }
