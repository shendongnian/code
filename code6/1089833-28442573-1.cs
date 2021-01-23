      private void button1_Click(object sender, EventArgs e)
      {
        textBox1.Clear();
        List<Person> people = objectListView1.Objects.Cast<Person>().ToList();
        var people = people.OrderBy(o => o.Name).ToList();
        foreach (var person in people)
        {
           Person p = person as Person;
           textBox1.Text += p.Id + "\t" + p.Name + "\t" + p.Birthday.ToShortDateString()  + "\r\n";
        }
      }
