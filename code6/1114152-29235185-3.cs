    using System;
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
