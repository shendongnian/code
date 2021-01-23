    public class Roll
    {
        public string Name { get; set; }
        private List<string> ingredients = new List<string>();
        public IList<string> Ingredients { get { return ingredients; } }
    
        public bool Contains(string ingredient)
        {
            return Ingredients.Any(i => i.Equals(ingredient));
        }
    }
