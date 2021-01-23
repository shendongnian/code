     private void Button1_Click(object sender, RoutedEventArgs e)
            {
                Debug.Print("'Set DataContext' button clicked");
                string tmp = tb.Text;
                tb.Text = "";
    
                tb.DataContext = _vm;
                tb.Text = tmp;
               
            }
