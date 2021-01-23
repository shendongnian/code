            foreach (DataGridViewRow dgvrow in dgv.Rows)
            {
                if (dgv.CurrentCell.ColumnIndex == dgv.Columns["Name"].Index)
                {
                    DataGridViewCell dgvcell = (DataGridViewCell)dgvrow.Cells["Name"];
                    string Name = dgvcell.Value.ToString();
                    string City = Name.Substring(Name.IndexOf("City:"));
                    Name = Name+"\r\n"+City;
                    dgvcell.Value = Name;
                }
            }
