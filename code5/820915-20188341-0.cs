    private void УчасткиGridControlDoubleClick(object sender, EventArgs e) {
    GridView view = (GridView)sender;
    Point pt = view.GridControl.PointToClient(Control.MousePosition);
    DoRowDoubleClick(view, pt);
    }
       private static void DoRowDoubleClick(GridView view, Point pt) {
    GridHitInfo info = view.CalcHitInfo(pt);
    if(info.InRow || info.InRowCell) {
        string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
        MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
    }
