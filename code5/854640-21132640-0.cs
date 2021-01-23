    public class NewViewModel 
    {
        // list of files with additional data
        public List<UploadItem> UploadItems { get; set; }
        
        public string AnotherPropForView { get; set; }
    }
    public class UploadItem
    {
        // your additional data
        public string CustomProp1  { get; set; }
        public string CustomProp2  { get; set; }
        // file
        public HttpPostedFileBase UpFile { get; set; }
    }
