    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var clickableGrid = new ClickableGrid(3, 3);
                DataContext = clickableGrid;
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var clickableGrid = (ClickableGrid) DataContext;
                ObservableCollection<MyItem> observableCollection = clickableGrid.MyItems;
            }
        }
    
        public class ClickableGrid : INotifyPropertyChanged
        {
            private int _columns;
            private ObservableCollection<MyItem> _myItems;
            private int _rows;
    
            public ClickableGrid(int columns, int rows)
            {
                Columns = columns;
                Rows = rows;
                UpdateArray();
            }
    
            public ObservableCollection<MyItem> MyItems
            {
                get { return _myItems; }
                set
                {
                    _myItems = value;
                    OnPropertyChanged();
                }
            }
    
            public int Columns
            {
                get { return _columns; }
                set
                {
                    _columns = value;
                    OnPropertyChanged();
                }
            }
    
            public int Rows
            {
                get { return _rows; }
                set
                {
                    _rows = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void UpdateArray()
            {
                int columns = Columns;
                int rows = Rows;
                if (columns <= 0) columns = 1;
                if (rows <= 0) rows = 1;
    
                var observableCollection = new ObservableCollection<MyItem>();
                for (int i = 0; i < columns*rows; i++)
                {
                    observableCollection.Add(new MyItem());
                }
                MyItems = observableCollection;
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class MyItem : INotifyPropertyChanged
        {
            private bool _isTicked;
    
            public bool IsTicked
            {
                get { return _isTicked; }
                set
                {
                    _isTicked = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public override string ToString()
            {
                return string.Format("IsTicked: {0}", _isTicked);
            }
        }
    }
