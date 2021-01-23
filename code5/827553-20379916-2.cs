    public class MyChoicesViewModel
    {
       public MyChoicesViewModel()
       {
         Selections = new ObservableCollection<ChoiceViewModel>();
         //Add first empty value
         AddNewItem();
         Selections.CollectionChanged += (sender, e) => 
         {
           // If you change the last add another
           if (e.NewItems.Contains(Selections.Last()))
             AddNewItem();
         }; 
       }
       public ObservableCollection<ChoiceViewModel> Selections {get; private set;}
       public void AddNewItem()
       {
         var newItem = new ChoiceViewModel();
         Selections.Add(newItem);
         newItem.PropertyChanged += () => 
          {
            //This is where we update the model from the ViewModel
            Model.Selections = from x in Selections
              select x.Value;
          }
        }
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
