        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lime;
            //Set time between ticks in miliseconds.
            timer1.Tick=2000;
            //Start timer, your program continues execution normaly
            timer1.Start;
            //If you use sleep(2000) your program stop working for two seconds.
           
        }
            //this event will rise every time set in Tick (from start to stop)
            private void timer1_Tick(object sender, EventArgs e)
            {
              //When execution reach here, it meas 2 secons have past. Stop Timer and change color
              timer1.Stop;
              button1.BackColor = SystemColors.Control;
            }
