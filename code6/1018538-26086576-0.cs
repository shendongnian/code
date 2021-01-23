    private void button1_Click(object sender, EventArgs e)
    {
        // #1. Make second form
        // If you want to make equivalent one, then change Form2 -> Form1
        Form2 form2 = new Form2();
        // #2. Set second form's size
        form2.Width = this.Width;
        form2.Height = this.Height;
        // #3. Set second form's start position as same as parent form
        form2.StartPosition = FormStartPosition.Manual;
        form2.Location = new Point(this.Location.X, this.Location.Y);
        // #4. Set parent form's visible to false
        this.Visible = false;
        // #5. Open second dialog
        form2.ShowDialog();
        // #6. Set parent form's visible to true
        this.Visible = true;
    }
