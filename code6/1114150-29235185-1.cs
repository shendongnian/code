    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication2
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MyModel();
            }
        }
    
        internal class MyModel : INotifyPropertyChanged
        {
            private DelegateCommand _myCommand;
    
            public MyModel()
            {
                MyCommand = new DelegateCommand(Execute);
            }
    
            public DelegateCommand MyCommand
            {
                get { return _myCommand; }
                set
                {
                    _myCommand = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void Execute(object o)
            {
                MessageBox.Show("Hello");
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class DelegateCommand : ICommand
        {
            private readonly Func<object, bool> _canExecute;
            private readonly Action<object> _execute;
    
            public DelegateCommand(Action<object> execute) : this(execute, s => true)
            {
            }
    
            public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
    
            public event EventHandler CanExecuteChanged;
        }
    }
