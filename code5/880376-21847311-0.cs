        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 1) // handle it some other way if you have multiselect.
            {
                int index = listView1.SelectedIndices[0];
                Person p = people[index];
                if (p != null)
                {
                    textBox1.Text = p.Name;
                    textBox2.Text = p.Email;
                    textBox3.Text = p.StreetAddress;
                    textBox4.Text = p.AddtionalNote;
                    dateTimePicker1.Value = p.Birthday;
                } 
            }
        }
