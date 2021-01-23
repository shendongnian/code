    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            Label lblClear = new Label();
            lblClear.Text = "X";
            lblClear.Font = this.Font;
            lblClear.Location = new Point(this.DisplayRectangle.X + (this.DisplayRectangle.Width - 15), this.Bounds.Y);
            lblClear.Size = new Size(15, 15);
            this.Controls.Add(lblClear);
        }
    }
