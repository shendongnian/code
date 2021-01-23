        private void submenu_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem.HasDropDownItems == false)
            {
                return; // not a drop down item
            }
            // Current bounds of the current monitor
            Screen CurrentScreen = Screen.FromPoint(this.Bounds.Location);
            // Look how big our children are:
            int MaxWidth = 0;
            foreach (ToolStripMenuItem subitem in menuItem.DropDownItems)
            {
                MaxWidth = Math.Max(subitem.Width, MaxWidth);
            }
            MaxWidth += 10; // Add a little wiggle room
            int FarRight = this.Bounds.Right + MaxWidth;
            int CurrentMonitorRight = CurrentScreen.Bounds.Right;
            if (FarRight > CurrentMonitorRight)
            {
                menuItem.DropDownDirection = ToolStripDropDownDirection.Left;
            }
            else
            {
                menuItem.DropDownDirection = ToolStripDropDownDirection.Right;
            }
        }
