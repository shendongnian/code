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
           Model.Selections = from x in Selections
                        select x.Value;
         }; 
       }
       public ObservableCollection<ChoiceViewModel> Selections {get; private set;}
    }
    public class ChoiceViewModel
    {
       public string Chosen {get;set;}
    }
