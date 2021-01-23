    public static class Extensions
    {
        public static IEnumerable<IEnumerable<XElement>> Partition(this IEnumerable<XElement> elements)
        {
            var currentList = new List<XElement>();
            var tags = new HashSet<string>();
            foreach (var xElement in elements)
            {
                if (tags.Contains(xElement.Name.LocalName))
                {
                    yield return currentList.ToArray();
                    currentList.Clear();
                    tags.Clear();
                }
                currentList.Add(xElement);
                tags.Add(xElement.Name.LocalName);
            }
            yield return currentList.ToArray();
        }
    }
