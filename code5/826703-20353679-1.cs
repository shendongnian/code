    public class CheckBoxValue: Selectable<string>
    {
       //.. no need for any special stuff here
    }
    public class myViewModel : ViewModelBase
    {
        public ObservableCollection<CheckBoxValue> CheckBoxCollection { get; set; }
    
        public myViewModel( Some Parameters.... )
        {
            CheckBoxCollection = new ObservableCollection<CheckBoxValue>();
    
            CheckBoxCollection.Add(new CheckBoxValue { Model = "CheckBox1" });
            CheckBoxCollection.Add(new CheckBoxValue { Model = "CheckBox2" });
            CheckBoxCollection.Add(new CheckBoxValue { Model = "CheckBox3 });
            //Setting IsSelected to false is redundant because bools default to false, so I removed that.
    
            //Calling NotifyPropertyChange in the constructor is also redundant because the object is just being constructed, therefore WPF did not even read the initial values from it yet.
    
           //Now, here we handle the Selection change:
           foreach (var item in CheckBoxCollection)
               item.OnIsSelectedChanged = OnCheckBoxSelectionChanged;
        }
    
        private void OnCheckBoxSelectionChanged()
        {
           //... etc    
        }    
