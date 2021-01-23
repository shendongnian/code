        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.DoDragDrop("duck", DragDropEffects.Copy);
            }
        }
        void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        void textBox1_DragOver(object sender, DragEventArgs e)
        {
            int index = textBox1.GetCharIndexFromPosition(textBox1.PointToClient(Cursor.Position));
            textBox1.SelectionStart = index;
            textBox1.SelectionLength = 0;
        }
        void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string txt = e.Data.GetData(DataFormats.Text).ToString();
            int index = textBox1.GetCharIndexFromPosition(textBox1.PointToClient(Cursor.Position));
            textBox1.SelectionStart = index;
            textBox1.SelectionLength = 0;
            textBox1.SelectedText = txt;
        }
