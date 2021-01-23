    public class MyViewModel
    {
    public ObservableCollection<MyDataItem> Items {get; set;}
    
    public MyViewModel()
    {
    Items=new ObservableCollection<MyDataItem>();
    
    loop //add your items to your 'Items' property so that you can bind this with LongListSelector ItemsSource
    {
    Items.Add(new MyDataItem("mystring"));
    }
    
    }
    
    
    
    }
    
    public class MyDataItem 
    {
    public MyDataItem(string s)
    {
    TextContent=s;
    }
    
    public string TextContent {get;set;}
    }
