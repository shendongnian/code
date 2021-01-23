    using System.Windows;
    using System.Collections.ObjectModel;
    namespace WpfApplication2
    {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public ObservableCollection<User>  basicUsers { get; private set; }
        public CustomTypeUsers customUsers { get; private set; } 
        public Window1()
       {
          InitializeComponent();
          basicUsers = new ObservableCollection<User>();
          basicUsers.Add(new User() { Name = "John Doe" });
          basicUsers.Add(new User() { Name = "Jane Doe" });
          customUsers = new CustomTypeUsers();
          customUsers.Add(new User() { Name = "Natasha Doe" });
          customUsers.Add(new User() { Name = "Angelina Doe" });
           DataContext = this;
       }
    }
    public class User
    {
       public string Name { get; set; }
    }
    public class CustomTypeUsers : ObservableCollection<User>
    {
        public CustomTypeUsers()
        {
            Add(new User() { Name = "John Doe" });
            Add(new User() { Name = "Betty Doe" });
        }
    }
    }
