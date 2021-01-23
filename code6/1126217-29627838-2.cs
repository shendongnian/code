     public string sum()
        {
            double sum = 0;
            string test;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    test = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    if (test != "")
                    {
                        sum += double.Parse(test);
                    }
                }                
            }
            return sum.ToString();
        }
