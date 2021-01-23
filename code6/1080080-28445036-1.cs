    public class MyViewModel : BindableBase
    {
        public MyViewModel()
        {
            foreach (var item in new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
                this.Items.Add(item);
        }
        ObservableCollection<int> _Items = new ObservableCollection<int>();
        public ObservableCollection<int> Items { get { return _Items; } }
        int _Index = default(int);
        public int Index { get { return _Index; } set { base.SetProperty(ref _Index, value); } }
        public DelegateCommand PrevCommand
        {
            get { return new DelegateCommand(() => { this.Index--; }); }
        }
        public DelegateCommand NextCommand
        {
            get { return new DelegateCommand(() => { this.Index++; }); }
        }
    }
