    using System.Collections.ObjectModel;
    using System.Linq;
    namespace XamLab1
    {
        public class ViewModelA : ObservableCollection<ViewModelB>
        {
            public string NameA { get; private set; }
            public ViewModelA(string name, ObservableCollection<ViewModelB> allBItems)
            {
                NameA = name;
                _allBItems = allBItems;
                _allBItems.CollectionChanged += _allBItems_CollectionChanged;
            }
            private ObservableCollection<ViewModelB> _allBItems;
            private void _allBItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                ClearItems();
                foreach (var item in _allBItems.Where(x => x.Parent == this))
                {
                    Add(item);
                }
            }
        }
    }
