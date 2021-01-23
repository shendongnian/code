    public class Persons
    {
        public Persons(string first, string last)
        {
            this.firstName = first;
            this.lastName = last;
        }
        public string firstName { set; get; }
        public string lastName { set; get; }
    }
...
            List<Persons> lst = new List<Persons>();
            lst.Add(new Persons("firstname", "lastname"));
            lst.Add(new Persons("firstname2", "lastname2"));
            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write("{0}: {2}, {1}", i, lst[i].firstName, lst[i].lastName);
                if (i == 1)
                {
                    lst[i].firstName = "firstname3";
                    lst[i].lastName = "lastname3";
                    Console.Write(" --> {1}, {0}", lst[i].firstName, lst[i].lastName);
                }
                Console.WriteLine();
            }
        }
