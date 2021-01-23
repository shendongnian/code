    public class Person : IComparable
    {
        public int Age { get; set; }
        public int CompareTo(int other)
        {
            return Age.CompareTo(other);
        }
        public int CompareTo(object obj)
        {
            Person otherPerson = obj as Person;
            if (obj == null)
                return 0;
            else
            {
                return Age.CompareTo(otherPerson.Age);
            }
        }
    }
