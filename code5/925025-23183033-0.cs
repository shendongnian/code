        public DataGridView cloneDataGridView(DataGridView oldDGV)
        {
            DataGridView newDGV = new DataGridView();
            foreach (DataGridViewCell cell in oldDGV.Rows[0].Cells)
                newDGV.Columns.Add(new DataGridViewColumn(cell));
            newDGV.Rows.Add(oldDGV.Rows.Count);
            for (int row = 0; row < oldDGV.Rows.Count; row++)
                for (int col = 0; col < oldDGV.Columns.Count; col++)
                    newDGV[col, row].Value = oldDGV[col, row].Value;
            return newDGV;
        }
