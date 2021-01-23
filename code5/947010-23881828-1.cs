    // Users that got access to a specific folder item
    public class User
    {
        public string userName {get; set; }
        public string accessType{get; set; }
        public string startDate {get; set; }
        public string endDate {get; set; }
    }
    // Inner object
    public class FolderListItem
    {
        public string folderPath { get; set; }
        public User[] userList { get; set; }
    }
    // See? List of Lists
    public class RootObject
    {
        public List<List<FolderListItem>> folderList { get; set; }
    }
    
    // Need to have a root object as the folder list is named.
    public ActionResult SomeMethod(RootObject data)
    {
    }
