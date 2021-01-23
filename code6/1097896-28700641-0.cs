    private void dgvPlayersPerTeam_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Country_CountryId" &&
                e.RowIndex >= 0 &&
                dgv["Country_CountryId", e.RowIndex].Value is int)
            {
                DataClassesFPDataContext db = new DataClassesFPDataContext();
                var countries = db.Countries.ToList();
                int countryId = (int)dgv["Country_CountryId", e.RowIndex].Value;
                string countryFull = (from country in countries
                                      where country.CountryId == countryId
                                      select country.Full).First().ToString();
                e.Value = countryFull;
                e.FormattingApplied = true;
            }
        }
