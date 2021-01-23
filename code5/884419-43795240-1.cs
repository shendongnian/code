       namespace WpfAppFoolAround
       {
         public partial class MainWindow : Window
         {
            public MainWindow()
            {
                InitializeComponent();
            }
            // -- Edit Controls ---------------------------------------------------------
            private void Do_Btn_EditPaste_Click(object sender, RoutedEventArgs e)
            {
                ContextControls.Btn_EditPaste(sender, e);
            }
         }
       }
