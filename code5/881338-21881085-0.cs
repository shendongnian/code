    public partial class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
    
        }
    
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            this.Rows[e.RowIndex].Selected = !this.Rows[e.RowIndex].Selected;
        }
    }
