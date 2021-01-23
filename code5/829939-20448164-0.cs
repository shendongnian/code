    private void txtMot_TextChanged(object sender, TextChangedEventArgs e)
    {
       if( motRechercher != null)
       {
         string sba = "";
          for (int i = 0; i <= motRechercher.Length; i++)
          {
              StringBuilder sb = new StringBuilder(motRechercher);
              sb[i] = '_';
              sba  = sb.ToString();
          } 
         txtMot.Text=sba;
       }
       else
       {
           txtMot = "";
       }
       
    }
