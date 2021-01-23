		private void button1_Click(object sender, EventArgs e)
        {
            using (Form frm = new Form())
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                // -> size is 80,80 with this line,
                // and wider if this line is commented out
                frm.MinimumSize = new Size(1, 1);
                frm.BackColor = Color.Orange;
                frm.Size = new Size(80, 80);
                frm.Click += (s, e2) =>  frm.Close();
				frm.ShowDialog(this);
			}
        }	
