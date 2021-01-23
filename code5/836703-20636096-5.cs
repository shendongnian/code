    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using Import_Rates_Manager;
    
    namespace Binding_a_List_to_a_ComboBox
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                DataContext = new coImportReader();
            }    
        }
    }
    namespace Import_Rates_Manager
    {
        public class coImportReader : INotifyPropertyChanged
        {
            private List<coSearchPoint> myItemsSource;
            private int mySelectedIndex;
            private coSearchPoint mySelectedItem;
    
            public List<coSearchPoint> SearchPointCollection 
            {
                get { return myItemsSource; }
                set
                {
                    myItemsSource = value;
                    OnPropertyChanged("SearchPointCollection ");
                }
            }
    
            public int MySelectedIndex
            {
                get { return mySelectedIndex; }
                set
                {
                    mySelectedIndex = value;
                    OnPropertyChanged("MySelectedIndex");
                }
            }
    
            public coSearchPoint MySelectedItem
            {
                get { return mySelectedItem; }
                set { mySelectedItem = value;
                OnPropertyChanged("MySelectedItem");
                }
            }
    
            #region cTor
    
            public coImportReader()
            {
                myItemsSource = new List<coSearchPoint>();
                myItemsSource.Add(new coSearchPoint { Name = "Name1" });
                myItemsSource.Add(new coSearchPoint { Name = "Name2" });
                myItemsSource.Add(new coSearchPoint { Name = "Name3" });
                myItemsSource.Add(new coSearchPoint { Name = "Name4" });
                myItemsSource.Add(new coSearchPoint { Name = "Name5" });
            }
            #endregion
    
            #region INotifyPropertyChanged Member
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
        }
    
        public class coSearchPoint
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
            public IRange FoundCell { get; set; }    
    
            public coSearchPoint()
            {
                Name = "";
                Id = Guid.NewGuid();
                FoundCell = null;    
            }
        }
    
        public interface IRange
        {
            string SomeValue { get; }
        }
    }
