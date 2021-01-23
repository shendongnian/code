                               FirstName = node.Element("FirstName").Value.ToString(),
                               LastName = node.Element("LastName").Value.ToString(),
                               Email = node.Element("Email").Value.ToString(),
                                                          };
            foreach (var item in customer)
            {
                var test = item.FirstName;
                Console.WriteLine(test);
            }
