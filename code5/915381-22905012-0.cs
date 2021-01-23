    if (listBoxSelectToLedger.Items.Count > 0)
            {
                for (int i = 0; listBoxSelectToLedger.Items.Count > i; i = 0)
                {
                    listBoxSelectToLedger.Items.Remove(listBoxSelectToLedger.Items[i].ToString());
                }
            }
            if (listBoxSelectFromLedger.SelectedItem != null)
            {
                foreach (DataRowView objDataRowView in listBoxSelectFromLedger.SelectedItems)
                {
                    listBoxSelectToLedger.Items.Add(objDataRowView["item_name"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No Item selected");
            }
