    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Animation;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private MyItem _itemToDelete;
    
            public ICommand DeleteCommand { get; private set; }
    
            public MainWindow()
            {
                InitializeComponent();
                DeleteCommand = new MyCommand<MyItem>(Delete);
    
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var fadeOutStoryBoard = TryFindResource("fadeOut");
                if (fadeOutStoryBoard != null && fadeOutStoryBoard is Storyboard)
                {
                    (fadeOutStoryBoard as Storyboard).Completed += fadeOutStoryBoard_Completed;
                }
            }
    
            void fadeOutStoryBoard_Completed(object sender, EventArgs e)
            {
                if (this._itemToDelete != null)
                {
                    MyItems myItems = Resources["myItems"] as MyItems;
                    myItems.Remove(this._itemToDelete);
                }
            }
    
            private void Delete(MyItem myItem)
            {
                this._itemToDelete = myItem;
            }
        }
    
        public class MyItem : DependencyObject
        {
            public static readonly DependencyProperty NameProperty =     DependencyProperty.Register("Name", typeof(string), typeof(MyItem));
            public string Name { get { return (string)GetValue(NameProperty); } set {     SetValue(NameProperty, value); } }
        }
    
        public class MyItems : ObservableCollection<MyItem>
        {
    
        }
    
        public class MyCommand<T> : ICommand
        {
            private readonly Action<T> executeMethod = null;
            private readonly Predicate<T> canExecuteMethod = null;
    
            public MyCommand(Action<T> execute)
                : this(execute, null)
            {
            }
    
            public MyCommand(Action<T> execute, Predicate<T> canExecute)
            {
                executeMethod = execute;
                canExecuteMethod = canExecute;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void NotifyCanExecuteChanged(object sender)
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged(sender, EventArgs.Empty);
            }
    
            public bool CanExecute(object parameter)
            {
                return canExecuteMethod != null && parameter is T ?     canExecuteMethod((T)parameter) : true;
            }
    
            public void Execute(object parameter)
            {
                if (executeMethod != null && parameter is T)
                    executeMethod((T)parameter);
            }
        }
    }
