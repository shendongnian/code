    private void calculateProductTwoColumns2(int castkaIndex2, int pocetIndex2, int tot_rows2)
    {
        try
        {
            double outVal = 0;
            foreach (DataGridViewRow row in dtg_ksluzby.Rows)
            {
                outVal += Convert.ToDouble(row.Cells[castkaIndex2].Value is DBNull ? 0 : row.Cells[castkaIndex2].Value) * 
                          Convert.ToDouble(row.Cells[procetIndex2].Value is DBNull ? 0 : row.Cells[pocetIndex2].Value);
            }
            kpriplac.Text = outVal.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Chybové hlášení K3 " + ex.Message.ToString());
        }
    }
