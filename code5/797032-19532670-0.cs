        private void Form1_Load(object sender, EventArgs e)
        {
           dateTimePicker1.CustomFormat = "h:mm";
           dateTimePicker1.MouseWheel += new MouseEventHandler(dateTimePicker1_MouseWheel);
           dateTimePicker1.KeyDown += new KeyEventHandler(dateTimePicker1_KeyDown);
           dateTimePicker1.GotFocus += new EventHandler(dateTimePicker1_GotFocus);        
        }
        void dateTimePicker1_GotFocus(object sender, EventArgs e)
        {
            SendKeys.Send("{right}");
        }
       
        void dateTimePicker1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(1);            
            else
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-1);            
        }   
        void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            {                
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 40)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-1);
                e.SuppressKeyPress = true;
            }
        }
