        using (TestDbContext context = new TestDbContext())
                {
                    foreach (Person person in People)
                    {
                        if (!(context.People.Any(p => p.ID == person.ID)))
                            context.People.Add(person);
                        else
                        {
                            context.People.Attach(person);
                            context.Entry<Person>(person).State = System.Data.EntityState.Modified;
                        }
                        context.SaveChanges();
                    }
                    foreach (Car caar in Cars)
                    {
                        if (!(context.Cars.Any(c => c.ID == caar.ID)))
                            context.Cars.Add(caar);
                        else
                        {
                            context.Cars.Attach(caar);
                            context.Entry<Car>(caar).State = System.Data.EntityState.Modified;
                        }
                        context.SaveChanges();
                    }
                    
                }
