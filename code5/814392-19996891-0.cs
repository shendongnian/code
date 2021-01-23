    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
     int c = 0;
    if (e.KeyCode == Keys.Tab)
            {
                TextBox txtRun = new TextBox(); 
                txtRun.Name = "txtDynamic"+c++; //name
                txtRun.Location = new System.Drawing.Point(20, 18+(20*c)); // Location of new control
                txtRun.Size = new System.Drawing.Size(200, 25); // size
                this.Controls.Add(txtRun);
             }
    }
