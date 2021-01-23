    public class CustomGrid : DataGridView
    {
        DataGridViewCell downButton;
        DataGridViewCell lastHoveredCell;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x201)//WM_LBUTTONDOWN = 0x201
            {
                HitTestInfo ht = TryHitTest(m);
                if (ht.Type == DataGridViewHitTestType.Cell)
                {
                    downButton = this[ht.ColumnIndex, ht.RowIndex];
                    if (SelectedCells.Count > 1&&downButton is DataGridViewButtonCell){                                    
                       InvalidateCell(ht.ColumnIndex, ht.RowIndex);
                       return;
                    }
                }
             } else if (m.Msg == 0x202) downButton = null; //WM_LBUTTONUP = 0x202
             else if (m.Msg == 0x200) { //WM_MOUSEMOVE = 0x200
                HitTestInfo ht = TryHitTest(m);
                if (ht.Type == DataGridViewHitTestType.Cell)
                {
                    if (lastHoveredCell != this[ht.ColumnIndex, ht.RowIndex]){
                        if(lastHoveredCell != null) InvalidateCell(lastHoveredCell);
                        lastHoveredCell = this[ht.ColumnIndex, ht.RowIndex];
                        InvalidateCell(lastHoveredCell);                        
                    }
                }
             }            
             base.WndProc(ref m);            
        }
        private HitTestInfo TryHitTest(Message m)
        {
            int x = m.LParam.ToInt32() & 0xffff;
            int y = m.LParam.ToInt32() >> 16;
            return HitTest(x, y);
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && this[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, false);
                Rectangle buttonBounds = e.CellBounds;
                string text = ((DataGridViewButtonColumn)Columns[e.ColumnIndex]).Text;
                var buttonState = System.Windows.Forms.VisualStyles.PushButtonState.Normal;
                if(buttonBounds.Contains(PointToClient(MousePosition))){
                    buttonState = MouseButtons == MouseButtons.Left && downButton == this[e.ColumnIndex, e.RowIndex] ?
                                  System.Windows.Forms.VisualStyles.PushButtonState.Pressed :
                                  System.Windows.Forms.VisualStyles.PushButtonState.Hot;
                }                                
                ButtonRenderer.DrawButton(e.Graphics, buttonBounds, text, e.CellStyle.Font, false, buttonState);                
            }
            else base.OnCellPainting(e);            
        }
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e) {
            base.OnColumnWidthChanged(e);            
            InvalidateColumn(e.Column.Index);
        }  
    }
