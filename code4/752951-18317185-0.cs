    public static class GroupEnumerable {
        public static IList<node> BuildTree(this IEnumerable<node> source)
        {
            var groups = source.GroupBy(i => i.parentKey);
        
            var roots = groups.FirstOrDefault(g => g.Key==null).ToList();
        
            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key!=null).ToDictionary(g => g.Key, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }
        
            return roots;
        }
        
        private static void AddChildren(node node, IDictionary<string, List<node>> source)
        {
            if (source.ContainsKey(node.key))
            {
                node.Children = source[node.key];
                for (int i = 0; i < node.Children.Count; i++)
                    AddChildren(node.Children[i], source);
            }
            else
            {
                node.Children = new List<node>();
            }
        } 
    }
