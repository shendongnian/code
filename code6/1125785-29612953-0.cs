    public void CountRowColor()
        {
            int red = 0, yellow = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Red)
                    red++;
                if (row.DefaultCellStyle.BackColor == Color.Yellow)
                    yellow++;
            }
            this.label14.Text = yellow.ToString();
            this.label16.Text = red.ToString();
        }
