    private void Button_Click(object sender, RoutedEventArgs e)
    {
        StringBuilder str = new StringBuilder();
        foreach (TextBlock item in Lbox.Items)
        {
           
               
                str.Append(item.Text + " ");
            
        }
        MessageBox.Show(str.ToString());
    }
