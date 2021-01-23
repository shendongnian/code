                AllowDrop = true;
    private void tsmi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                DoDragDrop(sender, System.Windows.Forms.DragDropEffects.Copy);
        }
