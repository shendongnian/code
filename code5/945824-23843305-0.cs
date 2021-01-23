    internal class MyViewModel
    {
        public ObservableCollection<Employee> Employees= new ObservableCollection<Employee>();
    
        // Populate Employee
    }
    
    public class MyWindow
    {
        public MyWindow()
        {
            DataContext = new MyViewModel();
        }
    }
