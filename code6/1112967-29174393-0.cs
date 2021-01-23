        void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            TextBox box = (this.listBox1.Items[e.Index] as TextBox);
            g.FillRectangle(new SolidBrush(box.BackColor), e.Bounds);
            g.DrawString(box.Text, box.Font, new SolidBrush(box.ForeColor), e.Bounds);
            e.DrawFocusRectangle();
        }
