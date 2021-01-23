        public void ChangeImg(Component ctrl)
        {
            if (ctrl is Button)
            { ((Button)ctrl).Image = Properties.Resources.keylock; }
            else if (ctrl is ToolStripButton)
            { ((ToolStripButton)ctrl).Image = Properties.Resources.keylock; }
        }
