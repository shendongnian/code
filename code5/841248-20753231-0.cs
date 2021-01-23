    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
             // Declare Dictionary
             Dictionary<string, string> dContacts = new Dictionary<string, string>();
             dContacts.Add("John", "07621456900");
             dContacts.Add("Jasper", "07843456377");
             dContacts.Add("June", "07935254678");
             dContacts.Add("Jim", "07945112623");
             dContacts.Add("Jackie", "07431733507");
             // Search facility for contacts
             Console.WriteLine("Who would you like to search for?");
             Console.Clear();
            
             Console.WriteLine("My top 5 contacts for that name are: ");
             Console.WriteLine();
             foreach (KeyValuePair<string, string> kvPair in dContacts)
             {
                Console.WriteLine("Name: {0} " + "- " + "Number: {1} ", kvPair.Key, kvPair.Value);
                Console.ReadKey();
             }
             // Prevent program from closing
             Console.WriteLine("Press any key to close");
             Console.ReadKey();
          }
       }
    }
