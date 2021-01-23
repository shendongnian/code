     private void Form1_Load(object sender, EventArgs e)
        {
            rbOne.Click += (s, o) => { status = rbOne.Text; };
            rbTwo.Click += (s, o) => { status = rbTwo.Text; };
        }
