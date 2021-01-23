        //Injects sender tag as string into status strip (used for MenuItems)
        private void menuItemTooltipEnter(object sender, EventArgs e)
        {
            var c = sender as ToolStripMenuItem;
            if (c == null) { toolStripStatusLabel1.Text = "null(0)"; return; }
            toolStripStatusLabel1.Text = Convert.ToString(c.Tag);
        }
