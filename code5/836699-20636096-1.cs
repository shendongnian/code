    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    
    namespace Binding_a_List_to_a_ComboBox
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                DataContext = new VM();
                InitializeComponent();
            }
    
        }
        public class VM : INotifyPropertyChanged
        {
            private List<MyClass> myItemsSource;
            private int mySelectedIndex;
            private MyClass mySelectedItem;
    
            public List<MyClass> MyItemsSource
            {
                get { return myItemsSource; }
                set
                {
                    myItemsSource = value;
                    OnPropertyChanged("MyItemsSource");
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
    
            public MyClass MySelectedItem
            {
                get { return mySelectedItem; }
                set { mySelectedItem = value;
                OnPropertyChanged("MySelectedItem");
                }
            }
    
            #region cTor
    
            public VM()
            {
                myItemsSource = new List<MyClass>();
                myItemsSource.Add(new MyClass { Id = 1, Name = "Name1", Otherstuff = "some Text 1" });
                myItemsSource.Add(new MyClass { Id = 2, Name = "Name2", Otherstuff = "some Text 2" });
                myItemsSource.Add(new MyClass { Id = 3, Name = "Name3", Otherstuff = "some Text 3" });
                myItemsSource.Add(new MyClass { Id = 4, Name = "Name4", Otherstuff = "some Text 4" });
                myItemsSource.Add(new MyClass { Id = 5, Name = "Name5", Otherstuff = "some Text 5" });
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
    
        public class MyClass
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Otherstuff { get; set; }
        }
    }
