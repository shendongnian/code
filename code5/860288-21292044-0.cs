     private void provjeri_unose()
        {
            string šifra = "šifra";
            for (int t = 0; t < dataGridView1.Rows.Count-1; t++)
            {
                DataGridViewRow row = dataGridView1.Rows[t];
                if (row.IsNewRow) break;
                šifra = Convert.ToString(dataGridView1.Rows[t].Cells[0].Value);
                Proizvod.Šifra = šifra;
                if (string.IsNullOrEmpty(Proizvod.Šifra))
                {
                    MessageBox.Show("Šifra mora biti unesena");
                }
            }
            
        }
