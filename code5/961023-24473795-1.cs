     public class CategoryViewModel : ViewModelBase
    {
        private string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => { Set<string>(ref _CategoryName, value); });
            }
        }
        private Uri _SelectedItem;
        public Uri SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() => { Set<Uri>(ref _SelectedItem, value); });
            }
        }
        private ObservableCollection<Uri> _Images;
        public ObservableCollection<Uri> Images
        {
            get { return _Images; }
            set { Set<ObservableCollection<Uri>>(ref _Images, value); }
        }
        public CategoryViewModel()
        {
            CategoryName = string.Empty;
            Images = new ObservableCollection<Uri>();
        }
    }
