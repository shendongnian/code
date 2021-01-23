    [System.ComponentModel.DesignerCategory("Code")]
    public class MyListView : ListView
    {
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // easy mouse selection
            if (MouseButtons == MouseButtons.Left)
            {
                var item = this.HitTest(e.Location).Item;
                if (item != null)
                    item.Selected = true;
            }
            base.OnMouseMove(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // ctrl-a - select all
            if (e.KeyCode == Keys.A && e.Control)
                SelectAll();
            base.OnKeyDown(e);
        }
    }
