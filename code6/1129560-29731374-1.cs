    public class CategorieViewModel : INotifyPropertyChanged
    {
        private List<string> _Categories = new List<string>();
        public List<string> Categories
        { 
            get
            {
               return _Categories;
            }
            set
            {
            _Categories = value;
            OnPropertyChanged("Categories");
            }
        }
        public void GetCategories()
        {
            Categories = GlobalVar._GlobalItem.SelectMany(a => a.tags)
               .OrderBy(t => t)
               .Distinct()
               .ToList();
        }
        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
