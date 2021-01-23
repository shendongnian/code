    public class Searchables
    {
        public List<ClassA> ListA { get; set; }
        public List<ClassB> ListB { get; set; }
        public List<ClassC> ListC { get; set; }
        public void SearchContents(Action<Status, Searchable, object> visitor)
        {
            SearchContent(this.ListA, visitor);
            SearchContent(this.ListB, visitor);
            SearchContent(this.ListC, visitor);
        }
        private static void SearchContent(
                IEnumerable<Searchable> searchees,
                Action<Status, Searchable, object> visitor)
        {
            foreach (var searchee in searchees)
            {
                visitor(searchee.Status, searchee, searchee.Id);
                foreach (var property in searchee.SearchableProperties)
                {
                    visitor(searchee.Status, searchee, property);
                }
            }
        }
    }
