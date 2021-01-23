    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    namespace WpfAsyncAwaitProgressbar
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new TestViewModel();
            }
        }
        public class TestViewModel : INotifyPropertyChanged
        {
            public TestViewModel()
            {
                Text1 = Text2 = Text3 = "Loading ...";
                loadData();
            }
            public string Text1 { get; private set; }
            public string Text2 { get; private set; }
            public string Text3 { get; private set; }
            public Visibility ProgressbarVisibility { get; private set; }
            private async void loadData()
            {
                setBusyMode(true);
                await Task.Run(() => getData1FromDB());
                await Task.Run(() => getData2FromDB());
                await Task.Run(() => getData3FromDB());
                setBusyMode(false);
            }
            private void getData1FromDB()
            {
                Thread.Sleep(3000);
                Text1 = "Data Result 1";
                raisePropertyChanged(() => Text1);
            }
            private void getData2FromDB()
            {
                Thread.Sleep(2000);
                Text2 = "Data Result 2";
                raisePropertyChanged(() => Text2);
            }
            private void getData3FromDB()
            {
                Thread.Sleep(1000);
                Text3 = "Data Result 3";
                raisePropertyChanged(() => Text3);
            }
            private void setBusyMode(bool isBusy)
            {
                ProgressbarVisibility = isBusy ? Visibility.Visible : Visibility.Hidden;
                raisePropertyChanged(() => ProgressbarVisibility);
            }
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void raisePropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
            {
                var memberExpression = (MemberExpression)projection.Body;
                raisePropertyChanged(memberExpression.Member.Name);
            }
            private void raisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion INotifyPropertyChanged
        }
    }
