        private void rmv_btn__MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                flp_panel.Controls.Remove( (Button) sender);
        }
