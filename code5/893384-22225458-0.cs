    public class BetterDataGridView : DataGridView
    {
        private DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
        public BetterDataGridView()
        {
        }
        protected override void OnRowStateChanged(int rowIndex, DataGridViewRowStateChangedEventArgs e)
        {
            base.OnRowStateChanged(rowIndex, e);
            if (rowIndex > -1)
            {
                DataGridViewRow row = this.Rows[rowIndex];
                if (row.Selected)
                {
                    Color oldColor = this.CurrentRow.DefaultCellStyle.SelectionBackColor;
                    e.Row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(oldColor.R < 235 ? oldColor.R + 20 : 0,
                                        oldColor.G, oldColor.B);
                }
                else if (!row.Selected)
                {
                    e.Row.DefaultCellStyle.SelectionBackColor = defaultStyle.SelectionBackColor;
                }
            }
        }
    }
