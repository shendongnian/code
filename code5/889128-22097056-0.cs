            foreach (Contact contact2 in List2)
            {
                List1.Remove(List1.FirstOrDefault(contact1 => contact1.FirstName == contact2.FirstName
                                                              && contact1.LastName == contact2.LastName
                                                              && contact1.IsAdmin == contact2.IsAdmin));
            }
