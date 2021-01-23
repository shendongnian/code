    public List<string> SomeComplexProperty {get;set;}
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      // NavigationEventArgs will return  "DestinationPage"
        DestinationPage _page = e.Content as DestinationPage;
        if (_page!= null)
        {
    
            _page.SomeComplexProperty = listObject;
        }
    }
