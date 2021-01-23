      private void button1_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (var v in listBox1.Items)
            {
                total += Convert.ToDecimal(v);
            }
            label1.Text = total.ToString();
        }
