    private void Button_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!(e.OriginalSource is TextBlock))
        {
            MessageBox.Show("You click on the button");
        }
    }
