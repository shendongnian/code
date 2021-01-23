            private void DataGridView1OnCellBeginEdit(object sender, DataGridViewCellCancelEventArgs args)
        {
            var isTicked = this.dataGridView1.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
            args.Cancel = (isTicked is bool) && ((bool)isTicked);
        }
