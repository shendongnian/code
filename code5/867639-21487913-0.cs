    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
    
        public string firstName;
        public string lastName;
    }
    
    
    
    public class People
    {
        private Person[] _people;
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];
    
            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }
    
        public PeopleEnumSimulator GetEnumerator()
        {
            return new PeopleEnumSimulator(_people);
        }
    
        public class PeopleEnumSimulator
        {
            public Person[] _people;
    
            int position = -1;
    
            public PeopleEnumSimulator(Person[] list)
            {
                _people = list;
            }
    
            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }
    
            public void Reset()
            {
                position = -1;
            }
    
            public Person Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }   
    // Now time to use the foreach (maybe in your codebehind)
     Person[] myPeople = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };
    
    
             
            People peopleList = new People(myPeople);
    
            foreach (Person p in peopleList)
                Response.Write(p.firstName + " " + p.lastName);
    ////****************************************
    ////******** A Generic Implementation********
    public class People<T>
    {
        private T[] _people;
        public People(T[] pArray)
        {
            _people = new T[pArray.Length];
    
            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }
    
        public PeopleEnumSimulator GetEnumerator()
        {
            return new PeopleEnumSimulator(_people);
        }
    
        public class PeopleEnumSimulator
        {
            public T[] _people;
    
            int position = -1;
    
            public PeopleEnumSimulator(T[] list)
            {
                _people = list;
            }
    
            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }
    
            public void Reset()
            {
                position = -1;
            }
    
            public T Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
    
    // use the foreach
       //For Type Person
            People<Person> peopleList = new People<Person>(myPeople);
    
            foreach (Person p in peopleList)
                Response.Write(p.firstName + " " + p.lastName);
    
            //break
            Response.Write(" </br></br></br>       ");
    
            //For Type Int
            int[] n3 = { 2, 4, 6, 8 };
    
            People<int> intList = new People<int>(n3);
    
            foreach (int p in intList)
                Response.Write(p);
