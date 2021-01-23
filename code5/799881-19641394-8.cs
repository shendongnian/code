    namespace Sample
    {
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Linq;
        using System.Runtime.CompilerServices;
    
        public sealed class MainWindowViewModel : INotifyPropertyChanged
        {
            private string _typedText;
            private string _selectedItem;
            private static readonly MainWindowViewModel Instance = new MainWindowViewModel();
    
            private MainWindowViewModel()
            {
                Items = new[] { "Apples", "Apples Green", "Bananas", "Bananas & Oranges", "Oranges", "Grapes" };
            }
    
            public static MainWindowViewModel CurrentInstance { get { return Instance; } }
    
            public string SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    if (value == _selectedItem) return;
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
    
            public string TypedText
            {
                get { return _typedText; }
                set
                {
                    if (value == _typedText) return;
                    _typedText = value;
                    OnPropertyChanged();
                    OnPropertyChanged("FilteredItems");
                }
            }
    
            public IEnumerable<string> Items { get; private set; }
    
            public IEnumerable<string> FilteredItems
            {
                get
                {
                    return Items == null || TypedText == null ? Items : Items.Where(x => x.ToLowerInvariant().Contains(TypedText.ToLowerInvariant()));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
