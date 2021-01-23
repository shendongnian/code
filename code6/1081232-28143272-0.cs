        public static void PromoteChildElementsToAttributes(XElement element)
        {
            foreach (var group in element.Elements().GroupBy(el => el.Name))
            {
                // Remove if you don't want this check.
                if (element.Elements().Any())
                {
                    //Uncomment if you want to skip elements with children.
                    //continue;
                }
                if (element.Attribute(group.Key) != null)
                {
                    Debug.WriteLine("Cannot add duplicate attribute " + element.Attribute(group.Key));
                    continue;
                }
                var value = group.Aggregate(new StringBuilder(), (sb, el) => sb.Append((string)el)).ToString();
                element.Add(new XAttribute(group.Key, value));
                foreach (var el in group)
                    el.Remove();
            }
        }
