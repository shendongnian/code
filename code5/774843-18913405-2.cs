First, make a  Hobby model class, with a single string property (you might change your mind later to add more properties, Idk) :
    public class Hobby : INotifyPropertyChanged
    {
        private string _name;
        public string Name { 
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged(); 
        }
        private bool _isSelected;
        public bool IsSelected 
        {
        get
        {
            return _isSelected;
        } 
        set
        {
            _isSelected = value;
            OnPropertyChanged();
        }
        //You can add some multiple properties here (***)
        public Hobby (string hobbyName, bool isSelected)
        {
             Name = hobbyName;
             IsSelected = isSelected;
        }
        //INotifiyPropertyChanged interface member implementation ...
    }
