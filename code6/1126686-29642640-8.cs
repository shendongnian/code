        static void Main(string[] args)
        {
            using (Context c = new Context())
            {
                Person p = new Person();
                p.Name = "Jenish";
                c.People.Add(p);
                c.Database.Log = Console.WriteLine;
                c.SaveChanges();
            }
        }
