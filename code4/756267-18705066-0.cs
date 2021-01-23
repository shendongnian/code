        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 1) && e.RowIndex != -1)
            {
                this.MyGrid[1, e.RowIndex].Value = !(bool)this.MyGrid[1, e.RowIndex].Value;
                this.MyGrid.EndEdit();
            }
        }
