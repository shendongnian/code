    public class MyClass
    {
        public string Name;
        public string Surname;
        public bool DoSomething(int value1, int value2)
        {
            return Name.Length == value1 || Surname.Length == value2;
        }
    }
