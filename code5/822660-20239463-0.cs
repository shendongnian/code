    private void MyButton_Click_1(object sender, RoutedEventArgs e)
    {
        MyImage.Visibility = System.Windows.Visibility.Hidden;
    }
 
    private void MyTextbox_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MyImage.Visibility = System.Windows.Visibility.Hidden;
        }
    private void MyWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MyImage.Visibility = System.Windows.Visibility.Hidden;
        }
