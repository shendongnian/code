    Button button = new Button();
    button.VerticalAlignment = System.Windows.VerticalAlignment.Top;
    button.Height = 75;
    button.Tag = tag;
    button.Background = new SolidColorBrush(colore);
    button.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
    button.Click += button_Click;
    button.Hold += button_Hold;
    
    void button_Hold(object sender, System.Windows.Input.GestureEventArgs e)
       {
          MessageBox.Show("Hold");
       }
    
    private void button_Click(object sender, RoutedEventArgs e)
      {
         MessageBox.Show("Click");
      }
