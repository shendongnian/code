    private Label label;  // field on the class (form)
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            label = new Label(); // instantiate new label
            label.Name = "customLabel";
            label.AutoSize = true;
            label.Text = "Dynamically Generated Label";
            label.Location = new Point(50, 50);
            label.BringToFront();
            this.Controls.Add(label);
        }
        else
        {
            if (label != null) // remove label
            {
                this.Controls.Remove(label);
                label = null;
            }
        }
    }
