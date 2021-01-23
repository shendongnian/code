            int sum = 0;
            for (int i = 0; i < radGridView1.Rows.Count - 1; ++i)
            {
                sum += int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString());
            }
            this.Text = sum.ToString();
