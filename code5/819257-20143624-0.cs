    void Rmv()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Remove();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        void Remove()
        {
                if (listView1.SelectedItems.Count > 0)
                {
                    Person person = new Person();
                    person = FindPerson(listView1.SelectedItems[0].Text);
                    people.RemoveAt(listView1.SelectedItems[0].Index);
                    foreach (ListViewItem eachItem in listView1.SelectedItems)
                    {
                        listView1.Items.Remove(eachItem);
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    if (listView1.SelectedItems.Count == 0)
                    {
                        textBox1.ReadOnly = false;
                        textBox2.ReadOnly = false;
                        textBox3.ReadOnly = false;
                        textBox4.ReadOnly = false;
                        textBox5.ReadOnly = false;
                        textBox6.ReadOnly = false;
                        dateTimePicker1.Enabled = true;
                        UserCount();
                    }
                }
                else
                {
                    MessageBox.Show("Nothing is selected! ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        void UserCount()
        {
            try
            {
                if ((listView1.Items.Count) == 0)
                {
                    toolStripLabel1.Text = Convert.ToString(listView1.Items.Count) + "& contacts";
                }
                else if ((listView1.Items.Count) == 1)
                {
                    toolStripLabel1.Text = Convert.ToString(listView1.Items.Count) + "& contact";
                }
                else
                {
                    toolStripLabel1.Text = Convert.ToString(listView1.Items.Count) + "& contacts";
                }
            }
            catch { }
        }
