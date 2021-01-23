    private void OnSquareRootClick(object sender, RoutedEventArgs e)
    {
         double number = 0;
         var isDouble = double.TryParse(tb.Text, out number);
         if(isDouble)
         {
             tb.Text = "\u221A" + tb.Text + " = " + Math.Sqrt(number);
         }
    }
    //XAML
    <Button Content="&#8730;" Click="OnSquareRootClick" />
