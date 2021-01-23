        public class Client : Person
        {
            public static Client GetClientFromPerson(Person p) 
            {
                if (p == null) 
                {
                    return null;
                }
                return new Client { FirstName = p.FirstName };
            }
        }
