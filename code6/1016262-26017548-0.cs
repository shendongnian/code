     public Contacts[] GetAllContacts()
        {
            List<Contacts> contacts = new List<Contacts>();
            const string filePath = "Contacts.txt";
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    do
                    {
                        Contacts contact = new Contacts();
                        contact.FirstName = sr.ReadLine();
                        contact.Surname = sr.ReadLine();
                        contacts.Add(contact);
                    } while (sr.Peek() != -1);
                }
            }
            return contacts.ToArray();
        }
