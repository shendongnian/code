    public class Human : IComparer<Human> 
    {
        public string Name { get; set; }
        public int Compare(Human first, Human second)
        {
            return  first .Name .ToCharArray().First().CompareTo(second.Name    .ToCharArray().First());
            
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            IComparer<Human> myCompare = new Human();
            Human[] myArray = new Human[3] { new Human() { Name = "Johny" }, new Human() { Name = "Alexander" }, new Human { Name = "Bobby" } };
            Array.Sort<Human>(myArray, myCompare);
            foreach (var item in myArray)
            {
                Console.WriteLine(item.Name);
            }
        } 
