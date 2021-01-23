        TimeSpan LastClick = DateTime.Now.TimeOfDay;
        private void button1_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                if (DateTime.Now.TimeOfDay.Subtract(LastClick).TotalMilliseconds < 500)
                    return;
            }
            LastClick = DateTime.Now.TimeOfDay;
            if(txtMessage.text != string.Empty)
            {
              // Insert into DB Method
                  txtMessage.Text = string.Empty;
            }
        }
