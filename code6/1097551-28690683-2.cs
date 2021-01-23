    using System;
    public class Person
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
    }
    public class ItemWrapper<T>
    {
        public T Item { get; private set; }
        public string DisplayMember { get; private set; }
        public ItemWrapper(T item, Func<T, string> displayFactory) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            if (displayFactory == null) {
                throw new ArgumentNullException("displayFactory");
            }
            this.Item = item;
            this.DisplayMember = displayFactory(item);
        }
        /// <summary>
        /// This method is just an example and should be removed
        /// </summary>
        public static void Example() {
            var person1 = new Person() { FirstName = "Johny", LastName = "Bravo" };
            var person2 = new Person() { FirstName = "Johny2", LastName = "Bravo" };
            var person3 = new Person() { FirstName = "Johny3", LastName = "Bravo" };
            var item1 = new ItemWrapper<Person>(person1, p => "First Name: " + p.FirstName);
            var item2 = new ItemWrapper<Person>(person2, delegate(Person p) { return "First Name: " + p.FirstName; });
            var item3 = new ItemWrapper<Person>(person3, DisplayFactory);
        }
        private static string DisplayFactory(Person p) {
            return "First Name" + p.FirstName;
        }
    }
}
