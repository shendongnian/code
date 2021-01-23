    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    namespace WpfApplication14
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                MenuItems = new ObservableCollection<MenuItemViewModel>
                {
                    new MenuItemViewModel { Header = "Alpha" },
                    new MenuItemViewModel { Header = "Beta",
                        MenuItems = new ObservableCollection<MenuItemViewModel>
                            {
                                new MenuItemViewModel { Header = "Beta1" },
                                new MenuItemViewModel { Header = "Beta2",
                                    MenuItems = new ObservableCollection<MenuItemViewModel>
                                    {
                                        new MenuItemViewModel { Header = "Beta1a" },
                                        new MenuItemViewModel { Header = "Beta1b" },
                                        new MenuItemViewModel { Header = "Beta1c" }
                                    }
                                },
                                new MenuItemViewModel { Header = "Beta3" }
                            }
                    },
                    new MenuItemViewModel { Header = "Gamma" }
                };
                DataContext = this;
            }
        }
        public class MenuItemViewModel
        {
            private readonly ICommand _command;
            public MenuItemViewModel()
            {
                _command = new CommandViewModel(Execute);
            }
            public string Header { get; set; }
            public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
            public ICommand Command
            {
                get
                {
                    return _command;
                }
            }
            private void Execute()
            {
                // (NOTE: In a view model, you normally should not use MessageBox.Show()).
                MessageBox.Show("Clicked at " + Header);
            }
        }
        public class CommandViewModel : ICommand
        {
            private readonly Action _action;
            public CommandViewModel(Action action)
            {
                _action = action;
            }
            public void Execute(object o)
            {
                _action();
            }
            public bool CanExecute(object o)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged
            {
                add { }
                remove { }
            }
        }
    }
