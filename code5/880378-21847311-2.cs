            if (listView1.SelectedItems.Count == 1) // handle it some other way if you have multiselect.
            {
                var item = listView1.SelectedItems[0];
                Person p = people.SingleOrDefault(x => x.Name == item.Text); 
                if (p != null)
                {
                    textBox1.Text = p.Name;
                    textBox2.Text = p.Email;
                    textBox3.Text = p.StreetAddress;
                    textBox4.Text = p.AddtionalNote;
                    dateTimePicker1.Value = p.Birthday;
                } 
            }
