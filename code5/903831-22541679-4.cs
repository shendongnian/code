    public class MainViewModel
    {
        ObservableCollection<PageViewModelBase> Pages {get;set;}
    
        PageViewModelBase ActivePage {get;set;}
    }
    
    public class PageViewModelBase
    {
       //.. logic common to all pages
    }
    
    public class PageViewModel1: PageViewModelBase
    {
       //.. logic which belongs to Page 1
    }
    
    public class PageViewModel2: PageViewModelBase
    {
       //.. logic which belongs to Page 2
    }
    //And so on...
