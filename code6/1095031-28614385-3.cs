	public static partial class XNodeExtensions
	{
        public static string LocalValue(this XContainer node)
        {
            if (node == null)
                return null;
            return string.Concat(node.Nodes().OfType<XText>().Select(tx => tx.Value));
        }
	}
