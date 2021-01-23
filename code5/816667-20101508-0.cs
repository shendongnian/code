    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            Person person = FindPerson(listView1.SelectedItems[0].Text);
            textBox1.Text = person.Name;
            textBox2.Text = person.Hometown;
            textBox3.Text = person.Address;
            textBox4.Text = person.Phone;
            textBox5.Text = person.Email;
            textBox6.Text = person.AdditionalInfo;
            dateTimePicker1.Value = person.Birthday;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            dateTimePicker1.Enabled = false;
            toolStripButton5.Enabled = true;
        }
