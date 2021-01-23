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
                list = new ObservableCollection<MyData>();
                for (int i = 1; i <= 100; i++)
                {
                    if (i == 3)
                        continue;
                    MyData d = new MyData() { id = i, name = "Name " + i.ToString() };
                    list.Add(d);
                }
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
                    MyData d = values[0] as MyData;
                    if (d == null)
                        return false;
    
                    ObservableCollection<MyData> list = values[1] as ObservableCollection<MyData>;
                    if (list != null)
                    {
                        // Check if any in the list have id - 1
                        if (list.Any(aa => aa.id == (d.id - 1)))
                            return false;
                        // Check if this is the lowest id
                        if (!list.Any(aa => aa.id < d.id))
                            return false;
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
