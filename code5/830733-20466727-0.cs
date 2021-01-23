    public void button1_Click(object sender, EventArgs e)
        {
            if (doorsOpen == true)
            {
                doorsOpen = false;
                richTextBox2.Text = "Doors closed";
            }
            pictureBox1.Visible = false; // This is the bottom floor doors closed picture
            pictureBox2.Visible = false; // This is the bottom floor doors open picture
            pictureBox3.Visible = true; // This is the top floor doors closed picture
            pictureBox4.Visible = false; // This is the top floor doors open picture
            floorOne = true; // HERE IS THE CHANGE
            button1.BackColor = Color.Yellow;
            button2.BackColor = Color.Gray;
            richTextBox1.Text = "First floor";
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button5.BackColor = Color.Red;
            button6.BackColor = Color.Black;
        }
