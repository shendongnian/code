    List<Person> persons = new List<Person>();
                Person person1 = new Person();
                person1.Attributes.Add("name", "Ross");
                person1.Attributes.Add("address", "Street 1");
                persons.Add(person1);
                Person person2 = new Person();
                person2.Attributes.Add("name", "Tom");
                person2.Attributes.Add("address", "Street 2");
                persons.Add(person2);
    
                List<KeyValuePair<string, string>> items = persons.Select(person => new KeyValuePair<string, string>(person.Attributes["name"].ToString(), person.Attributes["address"].ToString())).ToList();
    
                dataGridView1.DataSource = items;
