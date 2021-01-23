      private void button1_Click(object sender, EventArgs e)
      {
        textBox1.Clear();
        var people = objectListView1.Objects.OrderBy(o => o.Name).ToList();
        foreach (var person in people)
        {
           Person p = person as Person;
           textBox1.Text += p.Id + "\t" + p.Name + "\t" + p.Birthday.ToShortDateString()  + "\r\n";
        }
      }
