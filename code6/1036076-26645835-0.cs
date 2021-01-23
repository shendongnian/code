        void MinResTimer_Elapsed(object sender, EventArgs e)
        {
            if (Play_On == true)
            {
                i++;
                MessageBox.Show("timed" + i.ToString());
            }
            if (i == 4)
            {
                Play_On = false;
                MinResTimer.Enabled = false;
                button1.Text = "Pause";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Play")
            {
                button1.Text = "Puase";
                MinResTimer.Enabled = true;
                i = 0;
                Play_On = true;
            }
            else
            {
                button1.Text = "Play";
                MinResTimer.Enabled = false;
                Play_On = false;
            }
        }
