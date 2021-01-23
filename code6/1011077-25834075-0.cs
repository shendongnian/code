                XElement doc = XElement.Load(reader);
                // using our ToDynamicList (Extenion Method)
                var people = doc.ToDynamicList();
                // loop through each person
                foreach (dynamic person in people.Where(X => X.Name == "Waseem"))
                {
                    Console.WriteLine("id:\t" + person.Id);
                    Console.WriteLine("Name:\t" + person.Name);
                    Console.WriteLine("Age:\t" + person.Age);
                    Console.WriteLine("----------------------------------");
                    try
                    {
                        // loop through children, if any
                        foreach(dynamic child in person.Children)
                        {
                            Console.WriteLine("\tid:\t" + child.Id);
                            Console.WriteLine("\tName:\t" + child.Name);
                            Console.WriteLine("\tAge:\t" + child.Age);
                        }
                        Console.WriteLine("----------------------------------");
                    }
                    catch(Exception ex)
                    {
                    }
                }
            }
