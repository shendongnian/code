          public partial class MainWindow : Window
          {
             public MainWindow()
             {
                InitializeComponent();
                MyViewModel mv = new MyViewModel();
                this.DataContext = mv;
                if (mv.CloseAction == null)
                    mv.CloseAction = new Action(() => this.Close());
              }
          }
         
