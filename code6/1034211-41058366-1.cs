        private int _selectedItemIndex;
        private Rectangle dragBoxFromMouseDown;
        private void CustomizationForListBox(ListBox listBox)
        {
            listBox.ItemHeight = 25;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += ListBox_DrawItem;
            listBox.MouseDoubleClick += listBox_MouseDoubleClick;
            listBox.MouseMove += listBox_MouseMoveHandler;
            listBox.MouseUp += listBox_MouseUp;
            listBox.MouseDown += (sender, e) =>
            {
                // Handle drag/drop
                if (e.Button == MouseButtons.Left)
                {
                    _selectedItemIndex = listBox.IndexFromPoint(e.Location);
                    // Remember the point where the mouse down occurred. The DragSize indicates
                    // the size that the mouse can move before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;
                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                                   e.Y - (dragSize.Height / 2)), dragSize);
                }
            };
        }
        private void listBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Reset the drag rectangle when the mouse button is raised.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void listBox_MouseMoveHandler(object sender, MouseEventArgs e)
        {
            // Handle drag and drop
            // To check if the Mouse left button is clicked
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Collapse current selection, now we know nothing is selected
                    Globals.ThisAddIn.Application.Selection.Collapse(WdCollapseDirection.wdCollapseEnd);
                    //Start Drag Drop
                    DoDragDrop((sender as ListControl).SelectedValue, DragDropEffects.Copy);
                    if (_selectedItemIndex != -1)
                    {
                        // If the drag/drop was successful, there dropped text must be selected
                        if (!String.IsNullOrWhiteSpace(Globals.ThisAddIn.Application.Selection.Text))
                        {
