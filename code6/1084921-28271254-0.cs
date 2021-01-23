    private void txtStudentID_TextChanged(object sender, EventArgs e)
            {
                timer1.Interval = (700);
                timer1.Enabled = true;
                timer1.Start();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Stop();
                a = txtStudentID.Text;
                displayData(a);// i put the txtStudentID.Clear() at the end of the method. I think i need some rest. :)
            }
