                /*List of Persons*/
                List<Person> persons = new List<Person>()
                                                              {
                                                                  new Student(){StudentId = "Std-01", Name = "Roy", Age = 24},
                                                                  new Student(){StudentId = "Std-02", Name = "Jhon", Age = 25},
                                                                  new Teacher(){TeacherId = "Tch-01", Name = "Roy", Age = 24},
                                                                  new Teacher(){TeacherId = "Tch-02", Name = "Jhon", Age = 25}
                                                              };
                /*predictions*/
                Expression<Func<Person, bool>> prediction = x => x.Name.Contains("o");
                /*Use the utility*/
                                                                        /*Get Teacher from Persons*/
                IQueryable<Teacher> filteredItems = persons.AsQueryable().WhereIf<Person, Teacher>(prediction);
                List<Teacher> result = filteredItems.ToList();
