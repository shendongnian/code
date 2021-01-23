    public class MyViewModel
    {
        public MyData SelectedItem {get;set;} //NotifyPropertyChanged(), etc.
    
        public DelegateCommand DeleteCommand {get;set;}
    
        void OnDelete()
        {
            //Here you delete SelectedItem, no need for CommandParameter
        }
    }
