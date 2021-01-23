                foreach (DataGridViewColumn col in dgvReconciledItems.Columns)
            {
                switch (col.Name)
                {
                    case "Column1":
                        col.HeaderText = "Header1";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        col.FillWeight = 30;
                        break;
                    case "Column2":
                        col.HeaderText = "Header2";
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        col.FillWeight = 10;
                        break;
                    
                    default:
                        col.Visible = false;
                        break;
                }
            }
