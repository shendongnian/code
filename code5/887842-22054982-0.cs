    public class PossibleItems
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public static PossibleItems Item1 = new PossibleItems() { Name = "My first item", Description = "The first of my possible items" };
        public static PossibleItems Item2 = new PossibleItems() { Name = "My second  item", Description = "The second  of my possible items" };
        private PossibleItems()
        {
        }
        public override int GetHashCode()
        {
            return (Name + ";" + Description).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(!(obj is PossibleItems)) return false;
            var other = obj as PossibleItems;
            return other.Name == Name && other.Description == Description;
        }
    }
---
    bool eq  = PossibleItems.Item1 == PossibleItems.Item1;
    Console.WriteLine(PossibleItems.Item1.Name);
