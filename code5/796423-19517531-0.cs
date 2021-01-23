      for (int i = 0; i < Buttons.Count; i++)
        {
                    Button newBtn = new Button();
                    newBtn.Content = Buttons[i];
                    newBtn.Height = 23;
                    newBtn.Tag=i;
                    stackPanel1.Children.Add(newBtn);
                    newBtn.Click += new RoutedEventHandler(newBtn_Click);
        }
        
    private void newBtn_Click(object sender, RoutedEventArgs e)
    {
           Button btn=sender as Button;
           int i=(int)btn.Tag;
    
           switch(i)
           {
             case 0:  /*do something*/ break;
             case 1:  /*do something else*/ break;
             default: /*do something by default*/ break;
           }
    }
