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
    namespace ListImageWithText
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
        private List<ImageWithText> _objectlist;
        public List<ImageWithText> ObjectList
        {
            get
            {
                return _objectlist;
            }
            set
            {
                _objectlist = value;
                OnNotifyPropertyChanged("ObjectList");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            ImageWithText iwt;
            this._objectlist = new List<ImageWithText>();
            iwt = new ImageWithText();
            iwt.Image = "App.ico";
            iwt.Text = "Away";
            this._objectlist.Add(iwt);
            iwt = new ImageWithText();
            iwt.Image = "App.ico";
            iwt.Text = "Available";
            this._objectlist.Add(iwt);
            iwt = new ImageWithText();
            iwt.Image = "App.ico";
            iwt.Text = "Offline";
            this._objectlist.Add(iwt);
            OnNotifyPropertyChanged("ObjectList");
        }
    }
    public class ImageWithText
    {
        public string Image { get; set; }
        public string Text { get; set; }
    }
    }
