    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApplication5
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<MyData> Datas = new ObservableCollection<MyData>();
            public MainWindow()
            {
                InitializeComponent();
                for (int i = 0; i < 100; i++)
                {
                    Datas.Add(new MyData() { Prop1 = "test prop" + i, Prop2 = "test prop" + i, });
                   
                }
                this.DataContext = Datas;  
            }
        }
        public class MyData
        {
            
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
    
    
        }
        public class ConvertItemToIndex : IValueConverter
        {
            private static int checkNumber; 
            #region IValueConverter Members
            //Convert the Item to an Index
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {                
                    return  "Check " +checkNumber++; 
    
                }
                catch (Exception e)
                {
                    throw new NotImplementedException(e.Message);
                }
            }
            //One way binding, so ConvertBack is not implemented
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    
    }
