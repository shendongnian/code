        private void plus()
        {
            bool IsDuplicate = false;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (textBox1.Text == dataGridView2.Rows[i].Cells[0].Value.ToString())
                {
                    IsDuplicate = true;
                    MessageBox.Show("duple");
                    break;
                }
            }
            if (!IsDuplicate)
                dataGridView2.Rows.Add(textBox1.Text.Trim(), pictureBox3.Image, pictureBox6.Image);
            textBox1.SelectAll();
            textBox1.Focus();
        }
