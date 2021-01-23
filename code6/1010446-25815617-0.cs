    using System;
    using System.Collections.ObjectModel;
    namespace WpfApplication1 {
        public sealed class MyData    {
            private ObservableCollection<MyDataRow> dataList;
            public ObservableCollection<MyDataRow> DataList { get { return dataList; } }
            public MyData() { dataList = new ObservableCollection<MyDataRow>(); }
            public void AddBlankRow() { DataList.Add(new MyDataRow(this)); }
        }
        public sealed class MyDataRow     {
            private readonly MyData myData;
            public MyDataRow(MyData myData) { this.myData = myData; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
        }
    }
    
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace WpfApplication1 {
        public partial class MainWindow : Window
        {
            public MainWindow() { InitializeComponent(); }
            private MyData Data { get { return (MyData)DataContext; } }
        
            void DataGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
            {
                var inputElement = VisualTreeHelper.GetChild(e.EditingElement, 0) as PasswordBox;
                if (inputElement != null)
                {
                    Keyboard.Focus(inputElement);
                }
            }
        
            private void Window_Loaded(object sender, RoutedEventArgs e) { DataContext = new MyData(); }
            private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) { }
            private void SaveExecute(object sender, ExecutedRoutedEventArgs e) { }
            private void NewExecute(object sender, ExecutedRoutedEventArgs e) { Data.AddBlankRow(); }
            private void CancelExecute(object sender, ExecutedRoutedEventArgs e) { Close(); }
        }
    
