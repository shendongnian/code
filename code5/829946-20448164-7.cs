    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
       if(motRechercher.Length > 0)
       {
         String str = new String('_', motRechercher.Length);
         txtMot.Text = str;
       }
    }
