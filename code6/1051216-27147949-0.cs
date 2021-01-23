    private void myButton1_Click(object sender, EventArgs e)
        {
            Button but = (sender as Button);
            but.BackColor = Color.Gold;
            // this changes the color of the panel
            but.Parent.BackColor = Color.Gold;
            // this changes the color of the form containing the panel
            if (but.Parent.Parent != null)
            {
                but.Parent.Parent.BackColor = Color.Gold;
            }
        }
