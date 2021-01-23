    public class CP210UserControl: UserControl
    {
       public CP210UserControl()
       {
           InitializeComponent();
       }
    
       private void Button_Click(object sender, RoutedEventArgs e)
       {
          var VM = DataContext as MyViewModel;
          if (VM != null)
              VM.GetNumberDevices();
       }
    }
