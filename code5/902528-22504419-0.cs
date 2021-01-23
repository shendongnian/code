    namespace Databinding
    {
        
        public partial class MainWindow : Window
        {
            Login LoginInfo;
            public MainWindow()
            {
                InitializeComponent();
                LoginInfo = new Login();
                Binding bindingLogin = new Binding();
                bindingLogin.Source = LoginInfo;
                bindingLogin.Path = new PropertyPath("Username");
                bindingLogin.Mode = BindingMode.TwoWay;
                bindingLogin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(this.TextUsername, TextBox.TextProperty, bindingLogin);
            }
          //... rest
       }
    
          
    }
