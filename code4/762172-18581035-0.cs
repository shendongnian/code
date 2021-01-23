    class Program
    {
        static void Main(string[] args)
        {
            string fn = @"c:\myfile.txt";
            IList list = new ArrayList();
            FileReader(fn, ref list);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }
        public static void FileReader(string filename, ref IList result)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string firstName;
                string lastName;
                string marks;
                while (!sr.EndOfStream)
                {
                    firstName = sr.EndOfStream ? string.Empty : sr.ReadLine();
                    lastName = sr.EndOfStream ? string.Empty : sr.ReadLine();
                    marks = sr.EndOfStream ? string.Empty : sr.ReadLine();
                    result.Add(new Person(firstName, lastName, marks));
                }
            }
        }
    }
    public class Person
    {
        string firstName;
        string lastName;
        int marks;
        public Person(string firstName, string lastName, string marks)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            if (!int.TryParse(marks, out this.marks))
            {
                throw new InvalidCastException(string.Format("Value '{0}' provided for marks is not convertible to type int.", marks));
            }
        }
    }
