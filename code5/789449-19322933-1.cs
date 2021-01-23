       StringBuilder sb = new StringBuilder();
       for (int i = 0; i < item.Length; i++)
       {
          sb.Append(item[i]);
          sb.Append(" ,");
       }
        
        txtSummary.Text = sb.ToString().Trim(',',' ');
