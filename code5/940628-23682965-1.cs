    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<MyData> list { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                list = new ObservableCollection<MyData>()
                {
                    new MyData() { id = 1, name="Name 1" },
                    new MyData() { id = 2, name="Name 2" },
                    // id = 3 is missing
                    new MyData() { id = 4, name="Name 4" },
                    new MyData() { id = 5, name="Name 5" },
                    new MyData() { id = 6, name="Name 6" }
                };
                DataContext = this;
            }
        }
    
        public class MyData
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    
        public class MissingRowCheckConverter : IMultiValueConverter
        {
            #region IMultiValueConverter Members
    
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values.Length > 1)
                {
                    DataGridRow row = values[0] as DataGridRow;
                    ObservableCollection<MyData> list = values[1] as ObservableCollection<MyData>;
                    if (row != null && list != null)
                    {
                        if (row.IsNewItem)
                            return false;
                        MyData d = row.Item as MyData;
                        if (d != null)
                        {
                            // Check if any in the list have id - 1
                            if (list.Any(aa => aa.id == (d.id - 1)))
                                return false;
                            // Check if this is the lowest id
                            if (!list.Any(aa => aa.id < d.id))
                                return false;
                        }
                    }
                }
                return true;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
