    //send data
    NavigationService.Navigate(new Uri("/MainPage.xaml?key=" + wrkTbx.Text + "&key2=" + wrkTbx2.Text, UriKind.Relative));
    
    //retrive the information 
    string key,stringKey2;
    int key2;
    if (NavigationContext.QueryString.TryGetValue("key", out key)){
      // use key value
    }
    if (NavigationContext.QueryString.TryGetValue("key2", out stringKey2)){
        key2 = Int32.Parse(stringKey2); // use key2 value
    }
