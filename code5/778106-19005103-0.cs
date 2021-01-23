    public partial class BasePage : PhoneApplicationPage
    {
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked");
        }
    }
     new public void Button_Click(object sender, RoutedEventArgs e)
     {
        base.Button_Click(sender, e);
     }
