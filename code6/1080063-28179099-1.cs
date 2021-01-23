       DialogResult dr = MessageBox.Show("Are you sure to delete the record", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        if (dr == DialogResult.Yes)
        {
            this.netWeightMasterDataBindingSource.RemoveCurrent();
            this.netWeightMasterDataBindingSource.EndEdit();
            this.net_Weight_Master_DataTableAdapter.Update(this.corsicanaNetWeightDataSet.Net_Weight_Master_Data);
            net_Weight_Master_DataDataGridView.Refresh();
            MessageBox.Show("Record Deleted");
        }
        if (dr == DialogResult.No)
        {
            Close();
        }
