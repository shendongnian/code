    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var businesscontacts = new List<businesscontacts>();
                var contacts = new List<contacts>();
                var contactcodes = new List<contactcodes>();
                var sendto = from bc in businesscontacts
                             from c in contacts
                             from cc in contactcodes
                             where bc.Contactid == c.Contactid && cc.Contactid == c.Contactid
                             select new
                             {
                                c.FirstName,
                                c.LastName
                             };
            }
        }
        class businesscontacts
        {
            public int Contactid { get; set; }
        }
        class contacts
        {
            public int Contactid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        class contactcodes
        {
            public int Contactid { get; set; }
        }
    }
