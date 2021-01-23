    private void subMenu_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem mnuItem = sender as ToolStripMenuItem;
            if (mnuItem.HasDropDownItems == false)
            {
                return; // not a drop down item
            }
            //get position of current menu item
            var pos = new Point(mnuItem.GetCurrentParent().Left, mnuItem.GetCurrentParent().Top);
            // Current bounds of the current monitor
            Rectangle bounds = Screen.GetWorkingArea(pos);
            Screen currentScreen = Screen.FromPoint(pos);
            // Find the width of sub-menu
            int maxWidth = 0;
            foreach (var subItem in mnuItem.DropDownItems)
            {
                if (subItem.GetType() == typeof(ToolStripMenuItem))
                {
                    var mnu = (ToolStripMenuItem) subItem;
                    maxWidth = Math.Max(mnu.Width, maxWidth);
                }
            }
            maxWidth += 10; // Add a little wiggle room
            int farRight = pos.X + mnuMain.Width + maxWidth;
            int farLeft = pos.X - maxWidth;
            
            //get left and right distance to compare
            int leftGap = farLeft - currentScreen.Bounds.Left;
            int rightGap = currentScreen.Bounds.Right - farRight;
            
            if (leftGap >= rightGap)
            {
                mnuItem.DropDownDirection = ToolStripDropDownDirection.Left;
            }
            else
            {
                mnuItem.DropDownDirection = ToolStripDropDownDirection.Right;
            }
        }
