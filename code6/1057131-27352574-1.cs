     private void BindToDataGridView(DataTable dataTable) 
        {
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                for (int i = 0; i < alTxnTypeId.Count; i++)
                {
                    if (dataTable.Rows[j].ItemArray[1].ToString() == alTxnTypeId[i].ToString())
                    {
                        (dgvTxnPermission.Rows[i].Cells[2].FindControl("chkRow") as CheckBox).Checked = true;
                        break;
                    }
                }
        }
    }
