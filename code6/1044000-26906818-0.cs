    public partial class Example : PhoneApplicationPage
    {
    
     private void Button_Click(object sender, RoutedEventArgs e)
            {    
                NavigationService.Navigate(new Uri("/Homepage.xaml", UriKind.RelativeOrAbsolute));   
            }  
    }
