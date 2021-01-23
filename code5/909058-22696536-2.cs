    public static class Extensions
    {
        public static bool ContainsNode(this IList<Node> nodes, Node value)
        {
            return nodes.Any(n => n.X == value.X && n.Y == value.Y).Count > 0;
        }
    }
