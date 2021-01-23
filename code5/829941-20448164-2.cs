    private void txtMot_TextChanged(object sender, TextChangedEventArgs e)
    {
       for (int i = 0; i <= motRechercher.Length; i++)
       {
           StringBuilder sb = new StringBuilder(motRechercher);
           sb[i] = '_';
           string sba = sb.ToString();
           txtMot.Text=sba;
       } 
       
    }
