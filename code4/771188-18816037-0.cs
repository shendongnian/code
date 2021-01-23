     private void button1_Click(object sender, EventArgs e);
     {
          DialogResult dr = MessageBox.Show("Do you want to open Google ?", "Someapp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          if (dr == DialogResult.Yes)
            {
                Process.Start("www.google.com");
            }
          else
            {
               //React as needed.
            }
     }
