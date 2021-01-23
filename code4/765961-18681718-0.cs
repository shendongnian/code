    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //This will prevent flicker
            typeof(TableLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(tableLayoutPanel1, true, null);
        }
        Point downPoint;
        bool moved;
        //This is used to store the CellBounds together with the Cell position
        //so that we can find the Cell position later (after releasing mouse).
        Dictionary<TableLayoutPanelCellPosition, Rectangle> dict = new Dictionary<TableLayoutPanelCellPosition, Rectangle>();
        //MouseDown event handler for all your controls (on the tableLayoutPanel1)
        private void Buttons_MouseDown(object sender, MouseEventArgs e) {
            Control button = sender as Control;
            button.Parent = this;            
            button.BringToFront();            
            downPoint = e.Location;            
        }
        //MouseMove event handler for all your controls (on the tableLayoutPanel1)
        private void Buttons_MouseMove(object sender, MouseEventArgs e) {
            Control button = sender as Control;
            if (e.Button == MouseButtons.Left) {
                button.Left += e.X - downPoint.X;
                button.Top += e.Y - downPoint.Y;
                moved = true;
                tableLayoutPanel1.Invalidate();
            }
        }
        //MouseUp event handler for all your controls (on the tableLayoutPanel1)
        private void Buttons_MouseUp(object sender, MouseEventArgs e) {
            Control button = sender as Control;
            if (moved) {
                SetControl(button, e.Location);
                button.Parent = tableLayoutPanel1;
                moved = false;
            }
        }
        //This is used to set the control on the tableLayoutPanel after releasing mouse
        private void SetControl(Control c, Point position) {
            Point localPoint = tableLayoutPanel1.PointToClient(c.PointToScreen(position));
            var keyValue = dict.FirstOrDefault(e => e.Value.Contains(localPoint));
            if (!keyValue.Equals(default(KeyValuePair<TableLayoutPanelCellPosition, Rectangle>))) {
                tableLayoutPanel1.SetCellPosition(c, keyValue.Key);
            }
        }
        //CellPaint event handler for your tableLayoutPanel1
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            dict[new TableLayoutPanelCellPosition(e.Column, e.Row)] = e.CellBounds;
            if (moved) {
                if (e.CellBounds.Contains(tableLayoutPanel1.PointToClient(MousePosition))) {
                    e.Graphics.FillRectangle(Brushes.Yellow, e.CellBounds);
                }
            }
        }
    }
