    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication5
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                DataContext = new MyObject();
            }
        }
    
        internal class MyObject
        {
            public MyObject()
            {
                AvailableCategories = new ObservableCollection<Category>(new List<Category>(new[]
                {
                    new Category
                    {
                        Name = "category1",
                        SubCategories = new List<Category>(new[]
                        {
                            new Category {Name = "subCategory1a"},
                            new Category {Name = "subCategory1b"}
                        })
                    },
                    new Category
                    {
                        Name = "category2",
                        SubCategories = new List<Category>(new[]
                        {
                            new Category {Name = "subCategory2a"},
                            new Category {Name = "subCategory2b"}
                        })
                    }
                }));
            }
    
            public ObservableCollection<Category> AvailableCategories { get; private set; }
        }
    
        public class Category
        {
            public string Name { get; set; }
    
            public List<Category> SubCategories { get; set; }
    
            public override string ToString()
            {
                return String.Format("Name: {0}", Name);
            }
        }
    }
