        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lime;
            timer1.Tick=2000;
            timer1.Start;
           
        }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
              timer1.stop;
              button1.BackColor = SystemColors.Control;
            }
