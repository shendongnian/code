    Public ObservableCollection<object> MyList
    {
       get 
       {
          return new ObservableCollection<object>(MySortedList);
       }
    }
