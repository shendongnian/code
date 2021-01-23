    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Contact(string firstName, string lastName, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }
        public static Contact[] LoadContacts(string csvFile)
        {
            return File.ReadLines(csvFile).Select(CreateFromCsvLine).ToArray();
        }
        private static readonly char[] separator = new[] { ',' };
        private static Contact CreateFromCsvLine(string line)
        {
            string[] split = line.Split(separator);
            return new Contact(split[0], split[1], split[2]);
        }
    }
