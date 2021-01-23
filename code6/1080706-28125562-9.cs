    public static class XmlNodeExtensions
    {
        public static string Path(this XmlElement element)
        {
            if (element == null)
                throw new ArgumentNullException();
            return element.AncestorsAndSelf().OfType<XmlElement>().Reverse().Aggregate(new StringBuilder(), (sb, el) => sb.Append("/").Append(el.Name)).ToString();
        }
        public static IEnumerable<XmlNode> AncestorsAndSelf(this XmlNode node)
        {
            for (; node != null; node = node.ParentNode)
                yield return node;
        }
        public static IEnumerable<XmlNode> DescendantsAndSelf(this XmlNode root)
        {
            if (root == null)
                yield break;
            yield return root;
            foreach (var child in root.ChildNodes.Cast<XmlNode>())
                foreach (var subChild in child.DescendantsAndSelf())
                    yield return subChild;
        }
    }
    public static class EnumerableExtensions
    {
        // Back ported from .Net 4.0
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");
            return ZipIterator(first, second, resultSelector);
        }
        static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            using (IEnumerator<TFirst> e1 = first.GetEnumerator())
            using (IEnumerator<TSecond> e2 = second.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                    yield return resultSelector(e1.Current, e2.Current);
        }
    }
