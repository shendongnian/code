    public partial class MainWindow : Window
    {
      private string _firstName;
      public void SetBttn_Click(object sender, RoutedEventArgs e)
      {
         //Setting the value to the class level scoped variable.
          _firstName = FirstNameTxtBox.Text;
      }
      private void GetBttn_Click(object sender, RoutedEventArgs e)
      {
        //Reading the value from the class level scoped variable.
         FirstNameTxtBox.Text = _firstName ;
      }
    }
