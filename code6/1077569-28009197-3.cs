    public interface IDebugPrints
    {
        string Info { get; set; }
        
        void ShowInfo();
    }
    
    public class Character : IDebugPrints
    {
        public string Info {get;set;}
        public void ShowInfo()
        {
            Console.WriteLine(Info);
        }
    }
    public class StoreList
    {
        private IList internalList;
        public StoreList(IList inList)
        {
            internalList = inList;
        }
        public void ShowAllInfo()
        {
            // I love the OfType<>() extension, it only returns the items of type IDebugPrints.
            foreach (var item in internalList.OfType<IDebugPrints>())
                item.ShowInfo();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();
            characters.Add(new Character { Info = "Character 1" });
            characters.Add(new Character { Info = "Character 2" });
            // And I want to pass that list
            StoreList sl = new StoreList(characters);
            sl.ShowAllInfo();
            Console.ReadKey();
        }
    }
