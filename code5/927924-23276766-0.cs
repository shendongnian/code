            List<string> strings = new List<string>();
            strings.Add("test1");
            IList<object> objectList = strings; // Error at compile time
            IEnumerable<object> objectEnumerable = strings; // Works fine, but is not an IList<object>
            IList<object> stringObjects = new List<object>(strings); // Works, but creates a whole new list to do it.
