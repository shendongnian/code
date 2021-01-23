    public class MyForm
    {
      private bool _b;
        private void gdcSVNDefaultView_MouseDown(object sender, MouseEventArgs e)
        {
            var vw = (GridView)sender;
            var hitInfo = vw.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == GridHitTest.RowGroupButton)
                return;
            _b = false;
            if (vw.IsGroupRow(hitInfo.RowHandle))
                _b = SelectChildRows(hitInfo.RowHandle, vw);
            DXMouseEventArgs.GetMouseArgs(e).Handled = _b;
        }
        private void gdcSVNDefaultView_MouseUp(object sender, MouseEventArgs e)
        {
            DXMouseEventArgs.GetMouseArgs(e).Handled = _b;
        }
        private static bool SelectChildRows(int r, GridView view)
        {
            if (!view.GetRowExpanded((r)))
                return false;
            if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
                view.ClearSelection();
            var childRowCount = view.GetChildRowCount(r);
            var first = view.GetChildRowHandle(r, 0);
            var last = (first + childRowCount - 1);
            view.SelectRange(first, last);
            return true;
        }
    }
