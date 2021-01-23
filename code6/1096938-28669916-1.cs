      public void valute()
      {
       int rowCount = dataGridView1.RowCount;
       decimal value = 0;
       for (int i = 0; i < rowCount; i++)
       {
           string text = dataGridView1.Rows[i].Cells[3].Value.ToString();
           if (evro_check.Checked)
               dataGridView1.Rows[i].Cells[3].Value = text.ToString("C", CultureInfo.GetCultureInfo("fr")); //€
           else if (dolar_check.Checked)
           {
               value = Decimal.Parse(text.Replace(',', '.'), CultureInfo.InvariantCulture);
               dataGridView1.Rows[i].Cells[3].Value = text.ToString("C", CultureInfo.GetCultureInfo("fr-CA")); //$
           }
           else
           {
               dataGridView1.Rows[i].Cells[3].Value = text.ToString("C", CultureInfo.GetCultureInfo("en-GB"));
           }
       }
      }
