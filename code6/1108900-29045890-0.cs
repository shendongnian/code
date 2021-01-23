    private void button1_Click(object sender, EventArgs e) {
        using (Form form = new Form())
        {
            form.Text = "About Us";
            form.Paint += (sender, e) =>
            {
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
                e.Graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
                e.Graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
            }
            // form.Controls.Add(...);
            form.ShowDialog();
        }
    }
