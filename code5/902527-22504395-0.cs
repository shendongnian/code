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
    using System.ComponentModel;
    namespace Databinding
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Login LoginInfo;
            Binding bindingLogin;
            public MainWindow()
            {
                InitializeComponent();
                LoginInfo = new Login();
                bindingLogin = new Binding();
                bindingLogin.Source = LoginInfo;
                bindingLogin.Path = new PropertyPath("Username");
                bindingLogin.Mode = BindingMode.TwoWay;
                bindingLogin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            }
            private void Confirm_Click(object sender, RoutedEventArgs e)
            {            
                BindingOperations.SetBinding(this.TextUsername, TextBox.TextProperty,    bindingLogin);
            
                if(LoginInfo.Username=="admin" && this.Password.Password=="admin")
                {
                    MessageBox.Show("Welcome!","Login Status");
                }
                else
                {
                    MessageBox.Show("Something is wrong!","Login Status");
                }
            }
            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
        public class Login:INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private string username;
            public string Username
            {
                get
                {
                    return username;
                }
                set
                {
                    username = value;
                    if(this.PropertyChanged!=null)
                    {
                        this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Username"));
                    }
                }
            }
        }
    }
    
