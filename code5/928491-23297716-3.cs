    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication15
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
    
                var objects = new ObservableCollection<MyObject>(new[]
                {
                    new MyObject {Name = "Object1", Points = new float[] {1, 2}},
                    new MyObject {Name = "Object2", Points = new float[] {3, 4}}
                });
                DataContext = objects;
            }
        }
    
        internal class MyObject
        {
            public Single[] Points { get; set; }
            public string Name { get; set; }
        }
    }
