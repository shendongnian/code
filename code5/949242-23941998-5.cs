    using System.Collections.ObjectModel;
    using System.Windows;
    namespace WpfApplication14
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                MenuItems = new ObservableCollection<MenuItemViewModel>()
                {
                    new MenuItemViewModel { Header = "Alpha" },
                    new MenuItemViewModel { Header = "Beta",
                        MenuItems = new ObservableCollection<MenuItemViewModel>()
                            {
                                new MenuItemViewModel { Header = "Beta1" },
                                new MenuItemViewModel { Header = "Beta2",
                                    MenuItems = new ObservableCollection<MenuItemViewModel>()
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
            public string Header { get; set; }
            public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        }
    }
