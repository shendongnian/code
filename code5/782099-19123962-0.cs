    private void btnGrafiek_Click(object sender, RoutedEventArgs e)
    {
        int height;
        if(int.TryParse(txt2010.Text,out height))
        {
           rct2010.Height = height;
        }
        else
        {
           rct2010.Height = 150;
        }
    }
