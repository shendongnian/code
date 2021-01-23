    internal class Program
    {
        public static void Main(string[] args)
        {
            var fruitDictionary = new Dictionary<string, string>
            {
                {"Apple", "Fruit"},
                {"Orange", "Fruit"},
                {"Spinach", "Greens"}
            };
            var fruitString = "Apple Orange Spinach Orange Apple Spinach";
            var result = string.Join(" ",
                fruitString.Split(' ').ToList().Select(i => fruitDictionary.ContainsKey(i) ? fruitDictionary[i] : i));
        }
    }
