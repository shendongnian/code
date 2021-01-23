     string tofind = dr["Ministryname"].ToString();
     for (int i = 0; i < cblMinistries.Items.Count; i++)
     {
          string ministry = (string)this.cblMinistries.Items[i];
    
          if (ministry  == tofind)
          {
               cblMinistries.SetItemChecked(i, true);
          }                     
      }
