     var filterTerms = new List<string>();
     foreach (Control c in this.Controls)
     {
         if (c is CheckEdit)
         {
            if (((CheckEdit)c).Checked)
            {
                 filterTerms.Add(c.Tag.ToString());
            }
         }
     }
     dt.DefaultView.RowFilter = string.Join(" AND ", filterTerms);
     
     
