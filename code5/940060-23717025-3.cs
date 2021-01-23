    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.Collection = new TestObservableCollection<object>() {new object(), new object(), new object()};
                this.ContentPanel.DataContext = this.Collection;
            }
    
            public TestObservableCollection<object> Collection { get; set; }
    
            private void IncrementButton_Click(object sender, RoutedEventArgs e)
            {
                this.Collection.GetDefaultView().MoveCurrentToNext();
            }
        }
    
        public class TestObservableCollection<T> : ObservableCollection<T>
        {
            public ICollectionView GetDefaultView()
            {
                return CollectionViewSource.GetDefaultView(this);
            }
        }
    }
