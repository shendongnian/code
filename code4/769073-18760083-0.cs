    public class ExtendedFrameworkElement : Grid
    {
        public ExtendedFrameworkElement()
        {
            Border b1 = new Border();
            b1.Padding = new Thickness(20);
            b1.Background = Brushes.Red;
            b1.MouseRightButtonUp += b1_MouseRightButtonUp;
            Border b2 = new Border();
            b2.Padding = new Thickness(20);
            b2.Background = Brushes.Green;
            b2.MouseRightButtonUp += b2_MouseRightButtonUp;
            b1.Child = b2;
            this.Children.Add(b1);
        }
       private void b1_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //DoSomeThing
            e.Handled = false;
        }
      private void b2_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //DoSomeThing
            e.Handled = false;
        }
    }
