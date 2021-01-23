        toolStripLabel1.MouseUp += new System.Windows.Forms.MouseEventHandler(toolStripLabel1_MouseUp);
        
        private void toolStripLabel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
