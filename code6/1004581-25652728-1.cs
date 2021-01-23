    using System;
    using System.Collections.Generic;
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
    
    namespace WpfApplication17
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public System.Data.DataTable Items { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("StringColumn", typeof(string));
                dt.Columns.Add("IntColumn", typeof(int));
                dt.Columns.Add("AColumn1", typeof(A));
                dt.Columns.Add("AColumn2", typeof(A));
                dt.Columns.Add("BColumn1", typeof(B));
                dt.Columns.Add("BColumn2", typeof(B));
    
                dt.Rows.Add(
                    "TestString",
                    123,
                    new A() { Name = "A1", GroupName = "GroupName", IsSelected = true },
                    new A() { Name = "A2", GroupName = "GroupName", IsSelected = false },
                    new B() { FullName = "B1", IsChecked=true },
                    new B() { FullName = "B2", IsChecked=false }
                );
    
                Items = dt;
                this.DataContext = this;
            }
    
            private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                DataTemplate dt = null;
                if (e.PropertyType == typeof(A))
                    dt = (DataTemplate)Resources["ATemplate"];
                else if (e.PropertyType == typeof(B))
                    dt = (DataTemplate)Resources["BTemplate"];
    
                if (dt != null)
                {
                    DataGridTemplateColumn c = new DataGridTemplateColumn()
                    {
                        CellTemplate = dt,
                        Header = e.Column.Header,
                        HeaderTemplate = e.Column.HeaderTemplate,
                        HeaderStringFormat = e.Column.HeaderStringFormat,
                        SortMemberPath = e.PropertyName // this is used to index into the DataRowView so it MUST be the property's name (for this implementation anyways)
                    };
                    e.Column = c;
                }
            }
        }
    
        public class A
        {
            public string Name { get; set; }
            public string GroupName { get; set; }
            public bool IsSelected { get; set; }
        }
    
        public class B
        {
            public string FullName { get; set; }
            public bool IsChecked { get; set; }
        }
    
        public class DataRowViewConverter : IValueConverter
        {
            #region IValueConverter Members
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                DataGridCell cell = value as DataGridCell;
                if (cell == null)
                    return null;
    
                System.Data.DataRowView drv = cell.DataContext as System.Data.DataRowView;
                if (drv == null)
                    return null;
    
                return drv.Row[cell.Column.SortMemberPath];
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
