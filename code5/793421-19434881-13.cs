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
          {
              //Correct uses of Code-Behind:
              //1 - Call ViewModel Methods:
              var response = VM.GetNumberDevices();
              //2 - UI-specific code which does not contain business logic:
              responseTextBlock.Background = response ? null : Brushes.Pink;
          }
       }
    }
