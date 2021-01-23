    public static class INodeExtensions
    {
        public static void SetValue<T>(this INode node, string key, T v)
        {
            if(v is INode)
            {
                // category node set value
                if(node is CategoryNode)
                {
                    // convert and set value
                }
                else
                {
                    throw new Exception("No children found.");
                }
            }
            else
            {
                // value node set value
            }
        }
    }
