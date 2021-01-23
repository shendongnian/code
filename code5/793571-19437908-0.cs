    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfApplication13
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ObservableCollection<string> _files = new ObservableCollection<string>();
            private string _selectedFile;
    
            public MainWindow()
            {
                InitializeComponent();
    
                foreach (var file in Directory.GetFiles(@"C:\"))
                {
                    Files.Add(file);
                }
            }
    
            void Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                Process.Start(SelectedFile);
            }
    
            public ObservableCollection<string> Files
            {
                get { return _files; }
                set { _files = value; }
            }
    
            public string SelectedFile
            {
                get { return _selectedFile; }
                set { _selectedFile = value; NotifyPropertyChanged("SelectedFile"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
