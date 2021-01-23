    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Category> _categoryLinkCollection;
        public ObservableCollection<Category> CategoryLinkCollection
        {
            get
            {
                return this._categoryLinkCollection;
            }
            set
            {
                if (value != this._categoryLinkCollection)
                {
                    this._categoryLinkCollection = value;
                    OnPropertyChanged("CategoryLinkCollection");
                }
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return this._selectedCategory;
            }
            set
            {
                this._selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
    }
