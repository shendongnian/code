    private void SetItemsToDataContext()
    {
        foreach (String Datei in Directory.GetFiles(@"C:\Contacts", "*.txt"))
        {
            String[] linesRead = File.ReadAllLines(Datei);
            if (linesRead.Length != 4)
            {
                continue;
            }
            Contact contactRead = new Contact();
            contactRead.Company = linesRead[0];
            contactRead.Gender = linesRead[1];
            contactRead.Name = linesRead[2];
            contactRead.FirstName = linesRead[3];
            dataGrid_Content.Items.Add(contactRead);
        }
    }
    public class Contact
    {
        public String Company { get; set; }
        public String Gender { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
    }
