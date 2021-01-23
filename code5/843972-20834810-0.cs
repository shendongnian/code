    public class OrganizationsViewModel : Base
    {
        private ObservableCollection<Organization> _List = new ObservableCollection<Organization>();
        public ObservableCollection<Organization> List
        {
            get
            {
                Retrieve();
                return _List;
            }
            set
            {
    			if(_List != value)
    			{
    				_List = value;
    				NotifyPropertyChanged("List");
    			}
            }
        }
    	
    	...
    	...
    }
