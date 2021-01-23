    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> GenerateEmails()
        {
            for (int i = 0; i < LastName.Length; i++)
            {
                yield return String.Format("{0}{1}@domain.com", FirstName, LastName.Substring(0, i+1));
            }
        }
    }
