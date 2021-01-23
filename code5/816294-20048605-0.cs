        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject obj)
        {
            foreach (var child in obj.GetChildren())
            {
                yield return child;
                foreach (var descendant in child.GetDescendants())
                {
                    yield return descendant;
                }
            }
        }
