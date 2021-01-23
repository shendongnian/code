        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add( e.Data.GetData(DataFormats.Text));
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) 
                pictureBox1.DoDragDrop(pictureBox1.ImageLocation, DragDropEffects.Copy);
        }
