        private void MouseClickedOrMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ChangeLabelBackColor(this.PointToClient(MousePosition));
            }
        }
