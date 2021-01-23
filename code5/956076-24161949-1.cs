    //keep this somewhere so you know where you are in the list
    var currentBatch = 0;
    private void SelectionChanged(sender object, ChangedEventArgs e)
    {
         var position = e.CurrentItemIndex % 25;
         if(position > currentBatch)
         {
              currentBatch = position;
              var newItems = GetOtherItems(currentBatch * 25);
              
              //take the global list of items and modify it;
              //because we are moving right we only need the last 25 so we
              //can skip the first 25
              coverflow= coverflow.Skip(25);
              
              //add your new items
              coverflow.AddRange(newItems);
              CarouselList.ItemsSource = coverflow; // you will have to clear the source first
         }
         else if(position < currentBatch)
         {
              currentBatch = position;
              var newItems = GetOtherItems(currentBatch * 25);
              
              //take the global list of items and modify it;
              //because we are moving left we only need the first 25 so we
              //can take the first 25
              coverflow= coverflow.Take(25);
              
              //add your new items
              newItems.AddRange(coverflow);
              coverflow = newItems;
              CarouselList.ItemsSource = coverflow; // you will have to clear the source first
         }
    }
