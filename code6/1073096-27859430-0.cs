    public class MyCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        public MyCheckBoxColumn()
        {
            CellTemplate = new MyCheckBoxCell();
        }
    }
    
    public class MyCheckBoxCell : DataGridViewCheckBoxCell
    {
        protected override void OnKeyUp(KeyEventArgs e, int rowIndex)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                if (EditingCellValueChanged)
                {
                    EditingCellFormattedValue = !(bool)EditingCellFormattedValue;
                }
            }
            else
            {
                base.OnKeyUp(e, rowIndex);
            }
        }
    }
