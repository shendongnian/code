    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication3
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<Group> Groups { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                Groups = new ObservableCollection<Group>();
                Groups.Add(new Group()
                {
                    Name = "Group1",
                    Tabs = new ObservableCollection<Tab>()
                    {
                        new Tab()
                        {
                            Name = "Tab11",
                            Tests = new ObservableCollection<Test>()
                            {
                                new Test() { Name = "Test111", IsEnabled = true },
                                new Test() { Name = "Test112", IsEnabled = false }
                            }
                        },
                        new Tab()
                        {
                            Name = "Tab12",
                            Tests = new ObservableCollection<Test>()
                            {
                                new Test() { Name = "Test121", IsEnabled = true },
                                new Test() { Name = "Test122", IsEnabled = false },
                                new Test() { Name = "Test123", IsEnabled = false }
                            }
                        }
                    }
                });
    
                Groups.Add(new Group()
                {
                    Name = "Group2",
                    Tabs = new ObservableCollection<Tab>()
                    {
                        new Tab()
                        {
                            Name = "Tab21",
                            Tests = new ObservableCollection<Test>()
                            {
                                new Test() { Name = "Test211", IsEnabled = true },
                                new Test() { Name = "Test212", IsEnabled = false },
                                new Test() { Name = "Test213", IsEnabled = true }
    
                            }
                        },
                        new Tab()
                        {
                            Name = "Tab22",
                            Tests = new ObservableCollection<Test>()
                            {
                                new Test() { Name = "Test221", IsEnabled = true },
                                new Test() { Name = "Test222", IsEnabled = false },
                                new Test() { Name = "Test223", IsEnabled = false }
                            }
                        }
                    }
                });
    
                DataContext = this;
            }
        }
    
        public class Group
        {
            public string Name { get; set; }
            public IList<Tab> Tabs { get; set; }
        }
    
        public class Tab
        {
            public string Name { get; set; }
            public IList<Test> Tests { get; set; }
        }
    
        public class Test
        {
            public string Name { get; set; }
            public bool IsEnabled { get; set; }
        }
    }
