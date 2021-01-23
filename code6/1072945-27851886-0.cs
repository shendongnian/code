    void Reload()
    {
    
      //This does not update the UI**
    
       _theArrivalsDepartures = MakeQuery.LiveTrainArrivals("London Paddington");
       DataContext = theArrivalsDepartures;
       ListBoxArr.ItemsSource = _theArrivalsDepartures.StationMovementList;
    }
