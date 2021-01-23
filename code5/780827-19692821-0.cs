    private void label_MouseEnter(object sender, System.EventArgs e)
        {
            Control ctl = sender as Control; // gets the label control
            Control panel = ctl.Parent; // gets the label's parent control, (Panel in this case)
            if (ctl != null)
            {
                ctl.Font = new Font(ctl.Font.Name, 11, FontStyle.Underline); // change the font of the Label and style...
                panel.BackColor = Color.Blue; // change the panel's backColor
                ctl.Cursor = Cursors.Hand;
                // do more with the panel & label 
            }
        }
