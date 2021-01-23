    using System;
    public MainPage()
    {
    InitializeComponent();
 
    Loaded += new RoutedEventHandler(MainPage_Loaded);
    }
    
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
    System.Uri myUri = new System.Uri("Your php page url");
    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
    myRequest.Method = "POST";
    myRequest.ContentType = "application/x-www-form-urlencoded";
    myRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback),myRequest);
    }
