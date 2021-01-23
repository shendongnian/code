        private void calculateProductTwoColumns2(int castkaIndex2, int pocetIndex2, int tot_rows2)
            {
                try
                {
                    double outVal = 0;
                    foreach (DataGridViewRow row in dtg_ksluzby.Rows)
                    {
                       Double cell1;
                       Double cell2;
                       if(Double.TryParse(row.Cells[castkaIndex2].Value, out cell1) && Double.TryParse(row.Cells[pocetIndex2].Value, outcell2 ))
                       {
                        outVal = outVal + cell1 * cell2;
                       }
                    }
        
                    kpriplac.Text = outVal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chybové hlášení K3 " + ex.Message.ToString());
                }
            }
