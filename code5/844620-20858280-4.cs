    public static class Services
    {
        public static ITimeProvider TimeProvider { get; set; }
        public static void UpdatePerson(Person p, string firstName, string lastName)
        {
            p.FirstName = firstName;
            p.LastName = lastName;
            p.ModifiedDate = TimeProvider.GetCurrentTime();
        }
    }
