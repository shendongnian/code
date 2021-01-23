      private void button1_Click(object sender, EventArgs e)
      {
        textBox1.Clear();
        List<Person> people = objectListView1.Objects.Cast<Person>().ToList();
        if (objectListView1.LastSortColumn != null)
        {
            switch (objectListView1.LastSortColumn.AspectName)
            {
                case "Name":
                    people = people.OrderBy(o => o.Name).ToList();
                    break;
                case "Id":
                    people = people.OrderBy(o => o.Id).ToList();
                    break;
                default:
                    break;
            }
        }
        foreach (var person in people)
        {
           Person p = person as Person;
           textBox1.Text += p.Id + "\t" + p.Name + "\t" + p.Birthday.ToShortDateString()  + "\r\n";
        }
      }
