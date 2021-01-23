    List<Person> list2 = new List<Person>();
    
                list2.Add(new Person() { Age = 80 });
                list2.Add(new Person() { Age = 45 });
                list2.Add(new Person() { Age = 3 });
                list2.Add(new Person() { Age = 77 });
                list2.Add(new Person() { Age = 45 });
    
                list2.Sort();
    
                foreach (Person item in list2)
                {
                    Console.WriteLine(item.Age);
                }
