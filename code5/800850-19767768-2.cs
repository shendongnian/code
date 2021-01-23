                /*List of Persons*/
                List<Person> persons = new List<Person>()
                                       {
                                           new Student(){StudentId = "Std-01", Name = "Roy", Age = 24},
                                           new Student(){StudentId = "Std-02", Name = "Jhon", Age = 25},
                                           new Teacher(){TeacherId = "Tch-01", Name = "Roy", Age = 24},
                                           new Teacher(){TeacherId = "Tch-02", Name = "Jhon", Age = 25}
                                       };
                /*predictions*/
                Expression<Func<Person, bool>> prediction = x => x.Name.Equals("Roy") && x.Age == 24;
                /*Use the utility*/
                                                           /*Get Teacher from Persons*/
                List<Teacher> filteredItems = persons.Where<Person, Teacher>(prediction).ToList();
