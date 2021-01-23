    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    
    
    namespace ToDoList
    {
        public partial class MainWindow
        {
            private ObservableCollection<string> _tasks;
            public MainWindow()
            {
                InitializeComponent();
                _tasks = new ObservableCollection<string>();
                taskList.ItemsSource = _tasks;
            }
            private void userTask_KeyDown(object sender, KeyEventArgs e)
            {
                
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _tasks.Add(userTask.Text);
            }
        }
    }
