    private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedPerson != null)
            {
                People.Remove(SelectedPerson);
                this.listView1.Items.Clear();
                foreach (var person in People)
                {
                    this.listView1.Items.Add(person.ToString());
                    this.listView1.Sorting = SortOrder.Ascending;
                }
                this.listView1.Refresh();
                this.button1.Enabled = false;
            }
        }
