    public class MyList
    {
    public int IntData {get;set;}
    public DateTime MyDate {get;set;}
    public string MyString {get;set;}
    }
    //Create list 
    List<MyList> myList = new List<MyList>();
    myList.add(new MyList{IntData =1,MyDate = DateTime.Now.Date,MyString ="abc"});
    myList.add(new MyList{IntData =2,MyDate = DateTime.Now.Date,MyString ="bcc"});
    myList.add(new MyList{IntData =3,MyDate = DateTime.Now.Date,MyString ="agggbc"});
    
    //save myList into IsolatedStorageSettings 
    
    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
    settings.Add("MyDataKey",myList);
    settings.Save();
    
    List<MyList> getSavedListData = new List<MyList>();
    if(settings.Contains("MyDataKey"))
    getSavedListData =(List<MyList>)settings["MyDataKey"] ;//Here is the data
