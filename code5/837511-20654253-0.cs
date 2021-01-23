    private void PopulateGridView()
    {
        var myRecords = new List<PhoneBookRecord>();
        myRecords.Add(new PhoneBookRecord { FirstName = "blah", LastName = "Blah", PhoneNumber = "1234" });
        myRecords.Add(new PhoneBookRecord { FirstName = "New", LastName = "Song", PhoneNumber = "132134" });
        temper.DataSource = myRecords; 
    }
    class PhoneBookRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
