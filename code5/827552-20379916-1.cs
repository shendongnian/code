    public class MyChoicesViewModel
    {
       public MyChoicesViewModel()
       {
         Selections = new ObservableCollection<ChoiceViewModel>();
         //Add first empty value
         Selections.Add(new ChoiceViewModel());
         Selections.CollectionChanged += (sender, e) => 
         {
           // If you change the last add another
           if (e.NewItems.Contains(Selections.Last()))
             Selection.Add(new Choice());
           //This is where we update the model from the ViewModel
           // I'm pretty sure that the collectionChanged will track when 
           // an item changes, but if not then we 
           Model.Selections = from x in Selections
                        select x.Value;
         }; 
       }
       public ObservableCollection<ChoiceViewModel> Selections {get; private set;}
    }
    public class ChoiceViewModel : INotifyPropertyChanged
    {
       private string _chosen;
       public string Chosen 
       {
         get { return _chosen; }
         set { 
               if (_chosen != value)
               {
                 _chose = value;
                 OnPropertyChanged();
               }
             }
        }
        public void OnPropertyChanged([CallerMemberName] string property)
        {
          var temp = PropertyChanged;
          if (temp != null)
          {
            temp(this, new PropertyChangedEventArgs(property));
          }
        }
     }
    }
