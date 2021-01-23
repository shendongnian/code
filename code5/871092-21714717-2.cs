    public class Parent : Bindable
    {       
        private string[] bindingNames;
        private string[] allowedProperties;
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private ObservableCollection<Child> children = new ObservableCollection<Child>();
        public ObservableCollection<Child> Children
        {
            get { return this.children; }
            set { children = value; }
        }
        public Parent()
        {
            this.children.CollectionChanged += children_CollectionChanged;
            bindingNames = new string[] { "NumberOfChildrenWithDegrees" };
            allowedProperties = new string[] { "HasUniversityDegree", "HasHighSchoolDegree" };
        }
        private void children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Object item in e.NewItems)
                    if (item is INotifyPropertyChanged)
                        (item as INotifyPropertyChanged).PropertyChanged += item_PropertyChanged;
            if (e.OldItems != null)
                foreach (Object item in e.OldItems)
                    (item as INotifyPropertyChanged).PropertyChanged -= item_PropertyChanged;
        }
        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (bindingNames != null)
                foreach (string item in bindingNames)
                    if (allowedProperties.Contains(e.PropertyName))
                        OnPropertyChanged(item);
        }
        public int NumberOfChildrenWithDegrees
        {
            get { return Children.Where(f => f.HasTwoDegrees).Count(); }
        }
    }
