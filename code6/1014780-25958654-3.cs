     public partial class UserControl1 : UserControl
        {
            
            public UserControl1()
            {
                (App.Current as App).UserControl1List.Add(this);
    
                InitializeComponent();
            }
        }
         public partial class App : Application
        {
            public App()
            {
                UserControl1List = new List<UserControl1>();
            }
            public List<UserControl1> UserControl1List
            {
                get;
               private set;
            }
        }
