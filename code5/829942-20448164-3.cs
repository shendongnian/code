    private void btnNext_Click(object sender, RoutedEventArgs e)
    {
       if(motRechercher.Length > 0)
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
    }
