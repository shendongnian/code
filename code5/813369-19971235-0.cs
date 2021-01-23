        public DataGridViewCell SelectedCell
        {
            get
            {
                return dataGridView1.SelectedCells.Count > 0 ? dataGridView1.SelectedCells[0] : null;
            }
        }
        public string SelectedValue 
        {
            get
            {
                var val = SelectedCell != null ? SelectedCell.Value : null;
                return val != null ? val.ToString() : null;
            }
            set
            {
                SelectedCell.Value = value;
            }
        }
