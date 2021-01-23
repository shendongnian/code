    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    namespace StylingIntroSample
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private ObservableCollection<Data> _db = new ObservableCollection<Data>();
        public ObservableCollection<Data> db {
            get { return _db; }
            set
            {
                _db = value;
                OnPropertyChanged("db");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadItems();
        }
        private void LoadItems()
        {
            db.Add(new Data { Name = "person1", Description = "sssssss", Price = 15 });
            db.Add(new Data { Name = "person2", Description = "okokok", Price = 12 });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
    public class Data
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
