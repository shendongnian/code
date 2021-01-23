    private void Form1_Load(object sender, EventArgs e)
    {
     DataTable dt = new DataTable();
     dt.Columns.Add("Id");
     dt.Columns.Add("Student Name");
     dt.Columns.Add("Address");
     dt.Columns.Add("Course");
            
            
     dt.Rows.Add("1", "Heisenberg", "123 Somwhere Lane, Alburque, NM-12345", "Chemistry101");
     dt.Rows.Add("2", "Jesse Pinkman", "N/A", "Meth101");
     dt.Rows.Add("3", "Hank" , "N/A 2", "DEA101");
     dt.Rows.Add("4", "Guss Fring", "Los Pollos Hermanos", "ChickenMaking102");
     dt.Rows.Add("5", "John Smith", "123 Nowhere Lane, Nowhereland, NW-12345", "English101");
     dataGridView1.DataSource = dt;
    }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();
                string value3 = row.Cells[2].Value.ToString();
                string value4 = row.Cells[3].Value.ToString();
                this.Cursor = Cursors.WaitCursor;
                
                SmtpClient client = new SmtpClient("smtpclient");
                // Specify the e-mail sender. 
                var from = new MailAddress("from@test.com");
                // Set destinations for the e-mail message.
                var sendTo = "to@test.com";
                // Specify the message content.
                var message = new MailMessage();
                message.From = from;
                message.To.Add(sendTo);
                message.Body = "<b>EMAIL MESSAGE</b><br/>" + "Put your email here!<br/> " + value1 + " " + value2 + " " + value3 + " " + value4;
                message.Subject = "Your email subject goes here!";
                message.IsBodyHtml = true;
                client.Send(message);
                // Clean up.
                message.Dispose();
                MessageBox.Show("Email Notification Sent!", "Message Sent", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
        }
