    private void MyPivot_SelectionChanged(object sender, SelectionChangedEventArgs args)
    {
        if(e.AddedItems.Contains(Pivot1))
        {
            if(_seenPivots.Contains(Pivot1))
                return;
            _seenPivots.Add(Pivot1);
            //Do stuff here
        }
    }
