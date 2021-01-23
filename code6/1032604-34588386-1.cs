    public class model
    {
       public string key{ get; set; }
       public int key2{ get; set; }
    }
    
    //send data
    Frame.Navigate(typeof(MainPage), new PassedData { key= "my name", key2= 10 });
    
    // get data
    protected override void OnNavigatedTo(NavigationEventArgs e){
        model= e.Parameter as model;
    }
