    foreach (DataGridViewColumn dc in dgvTestParameter.Columns)
            {
                if (dc.Index.Equals(0) || dc.Index.Equals(4))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }
            }
