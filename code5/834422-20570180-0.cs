        private static void Main(string[] args)
        {
            var list = new List<object> {new {prop1 = "A", prop2 = "B"},new {prop3 = "B", prop4 = "C"}};
            var subList = SearchForStringInProperties(list, "C");
        }
        private static IEnumerable<object> SearchForStringInProperties(IEnumerable<object> list, string searchString)
        {
            return from obj in list where FindStringInObjProperties(obj, searchString) select obj;
        }
        private static bool FindStringInObjProperties(object obj, string searchString)
        {
            return obj.GetType().GetProperties().Any(property => obj.GetType().GetProperty(property.Name).GetValue(obj).ToString().Equals(searchString));
        }
