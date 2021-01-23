    // content should obviously be whatever object type you need to get
    // (or already have)
    public void Shuffle(List<object> content)
    {
        // Note: you don't have to initialize an observable collection like this.
        // You can also create a list, shuffle it as you would normally, then call
        // new ObservableCollection<whatsnewCompleteData(shuffledList);
        var newWhatsnewCompleteList = new ObservableCollection<whatsnewCompleteData>();
    
        for (int i = 0; i < whatsnewfeed.feed.entry.Count; i++)
        {              
            newWhatsnewCompleteList.Add(new whatsnewCompleteData(i, content[i]);
        }
        WhatsNewCompleteList = newWhatsnewCompleteList;
    }
