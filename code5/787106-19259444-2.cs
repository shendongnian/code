    public class Student { public string FirstName; }
    public partial class MainWindow : Window
    {
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            if (string.isNullOrEmpty(txtFirstName.Text))
                throw new Exception("Please type first name!");
            myOnlyStudent.FirstName = txtFirstName.Text;
        }
    }
