    public Contacts[] getAllContacts()
    {
        List<Contacts> theContactList = new List<Contacts>();
        string file_name = "Contacts.txt";
        string textLine = "";
        bool firstNameLine = true;
        if (System.IO.File.Exists(file_name) == true)
        {
            System.IO.StreamReader objReader;
            objReader = new System.IO.StreamReader(file_name);
            Contact newContact;
            do
            {
                textLine = objReader.ReadLine();
                if (firstNameLine)
                {
                    newContact = new Contact();
                    newContact.firstName = textLine;
                }
                else
                {
                    newContact.sureName = textLine;
                    theContactList.Add(newContact);
                }
                
                firstNameLine = !firstNameLine;
            } while (objReader.Peek() != 1);
        }
        if (theContactList.Count > 0)
        {
            return theContactList.ToArray();
        }
        else
        {
            return null;
        }
    }
