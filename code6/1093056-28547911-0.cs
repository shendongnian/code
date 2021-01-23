    public class FileInformation
    {
        public string title {get;set;}
        public string value {get;set;}
    }
    
    public string image_list()
    {
    
    	//Set up the list of acceptible extensions
        string[] arr = new string[3]; // Initialize
        arr[0] = ".jpg";               // Element 1
        arr[1] = ".png";               // Element 2
        arr[2] = ".gif";             // Element 3
    
        //Declare the variable
        var filePath = "";
    
        //Set the path 
        filePath = Server.MapPath("~/images/");
    
    
       //Start the string for the list
       var list = new List<FileInformation>();
    
       //Get the filesnames from the path
       string[] fileNames = Directory.GetFiles(filePath, "*", SearchOption.TopDirectoryOnly);
    
       //Loop through each of the file names
       foreach (string filename in fileNames)
       {
       		//Get the information on the filename
    		FileInfo fileInfo = new FileInfo(filename);
    
    		//Loop through each of extension provided
            foreach (var ext in arr) {
            	//If the extenion on the filename matches one of the list then...
                if (fileInfo.Extension == ext) {
                	//Add the filename and location to the list in the title: filename, value: "images/filename" format
    				list.Add(new FileInformation(){ title = fileInfo.Name, value = "images/" + fileInfo.Name });
                }
    		}
        }
    
    	//Convert the list to a JSON string using JSON.net (use the correct framework format)
    	var yourJSONString = JsonConvert.SerializeObject(list);
    	//Return the JSON string for use in the javascript call.
    	return yourJSONString;
    }
