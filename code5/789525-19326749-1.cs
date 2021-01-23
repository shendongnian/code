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
    using System.ComponentModel;
    using Microsoft.Win32;
    using System.IO;
    using System.Diagnostics;
    namespace ListBoxFiles
    {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private List<FileInfo> _fileList;
        public List<FileInfo> FileList
        {
            get
            {
                return _fileList;
            }
            set
            {
                _fileList = value;
                OnNotifyPropertyChanged("FileList");
            }
        }
        private FileInfo _currentFile;
        public FileInfo CurrentFile
        {
            get
            {
                return _currentFile;
            }
            set
            {
                _currentFile = value;
                OnNotifyPropertyChanged("CurrentFile");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox caller = (ListBox)sender;
            FileInfo fi = (FileInfo)caller.SelectedItem;
            Process.Start(fi.FullName);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.Multiselect = true;
            bool dialogResult = (bool)ofd.ShowDialog();
            if (dialogResult)
            {
                this._fileList = new List<FileInfo>();
                FileInfo fi;
                foreach (string filename in ofd.FileNames)
                {
                    fi = new FileInfo(filename);
                    this._fileList.Add(fi);
                }
                OnNotifyPropertyChanged("FileList");
            }
        }
    }
    }
