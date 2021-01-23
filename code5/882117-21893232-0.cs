    private RootObject[] InitialFeed { get; set; } 
    
    
    public void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
       InitialFeed = JsonConvert.DeserializeObject<RootObject[]>(e.Result);       
    
      listBox1.ItemsSource = InitialFeed ;
    
    }
    
    private void on_click(object sender, SelectionChangedEventArgs e) //listbox selectionchanged event
    {
       listBox1.ItemsSource = InitialFeed.Where(itm => itm.SomeSubProperty == listbox1.SelectedValue)
                                         .ToList();
         
    }
