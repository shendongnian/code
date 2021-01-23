        private void button1_Click(object sender, EventArgs e)
        {
            float salary;
            DateTime date;
            if (float.TryParse(tbSalary.Text, out salary))
            {
                if (DateTime.TryParse(tbStartDate.Text, out date))
                {
                    // ... proper code to update your database but COMMENTED OUT ...
                    MessageBox.Show("Changes Saved");
                }
                else
                {
                    MessageBox.Show("Date must be MM/DD/YY form");
                }
            }
            else
            {
                MessageBox.Show("Salary must be a numeric value");
            }
        }
