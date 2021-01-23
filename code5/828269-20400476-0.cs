    public People Selected1
    {
        get
        {
            return _selected1;
        }
    
        set
        {
            var pc = PropertyChanged;
            UpdateList (SourceCollection2, _selected, value);
            if (pc != null)
            {
                _selected1 = value;
                pc(this, new PropertyChangedEventArgs("Selected1"));
            }
            
        }
    }
    
    private void UpdateList(ObservableCollection<People> list, People oldItem, People newItem){
        if(!list.Contains(oldItem)){
            list.Add(oldItem);
        }
        if(list.Contains(newItem)){
            list.Remove(newItem);
        }
    }
