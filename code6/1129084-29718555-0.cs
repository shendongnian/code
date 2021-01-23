    public class Person
    {
        public string Name { get; set; }
        public List<Person> Children { get; set; }
        public Person()
        {
            Children = new List<Person>();
        }
        public void DisplaySuccessors(int indendationLevel = 0)
        {
            Console.WriteLine("{0}{1}", new String('.', indendationLevel * 2), Name);
            foreach (var child in Children)
            {
                child.DisplaySuccessors(indendationLevel + 1);
            }
        }
    }
