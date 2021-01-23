    dgSupplier.DataSource = dsSup.Tables["tblSupplier"];
            dgSupplier.Columns["Telephone"].Width = 70;
            foreach (DataGridViewColumn col in dgSupplier.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
