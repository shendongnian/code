     ..................................................
        for (int i = 0; i < grvData.Rows.Count; i++)
        {
         if (grvData.Rows[i].Cells[22].Text == "AU")
         {
         string strDate = grvData.Rows[i].Cells[3].Text;
         DateTime presenetDate;           
         if (DateTime.TryParseExact(strDate, new string[] { "MM/d/yyyy h:m:s tt" },
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out datDate))
         {
           G = (Date - presenetDate).TotalDays;
               AUDay1.Text = Convert.ToString(G);
         }
         else
         {
           AUDay1.Text = "Not a Valid date";
         }
       .......................................
         
