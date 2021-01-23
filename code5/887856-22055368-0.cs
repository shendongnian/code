    <ComboBox ItemsSource="{Binding MyCollection}"
              SelectedItem="{Binding SelectedItem}"/>
    public class ViewModel
    {
        public ObservableCollection<MyItems> MyCollection {get;set;}
    
        private void _selectedItem;
        public MyItem SelectedItem
        {
           get { return _selectedItem; }
           set
           {
               _selectedItem = value;
               NotifyPropertyChanged();
    
               DoStuffWhenComboIsChanged();
           }
        }
    
        private void DoStuffWhenComboIsChanged()
        {
           //... Do stuff here
        }
    }
