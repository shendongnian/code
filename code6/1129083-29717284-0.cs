    static void Main(string[] args)
            {
                List<Person> successors = new List<Person>();
    
                var person = new Person()
                {
                    Name = "GrandFather",
                    Children = new List<Person>()
                    {
                        new Person()
                        {
                            Name = "Son",
                            Children = new List<Person>()
                            {
                                new Person()
                                {
                                    Name = "SonOfSon"
                                }
    
                            }
                        },
                        new Person()
                        {
                            Name = "Daughter",
                            Children = new List<Person>()
                            {
                                new Person()
                                {
                                    Name = "DaughterOfDaughter"
                                }
                            }
                        }
                    }
                };
    
                SearchForSuccessors(person.Children, successors);
            }
    
            public static void SearchForSuccessors(List<Person> persons, List<Person> successors)
            {
                foreach(var person in persons )
                {
                    successors.Add(person);
    
                    if (person.Children != null)
                        SearchForSuccessors(person.Children, successors);
                }
            }
