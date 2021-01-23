    public static IEnumerable<T> Traverse<T>(
        this T root, 
        Func<T, IEnumerable<T>> childrenSelector) {
        var head = new ForwardLink<T>(childrenSelector(root));
        if (head.Value == null) yield break; // No items from root iterator
        while (head != null)
        {
            var headValue = head.Value;
            var localTail = head;
            var second = head.Next;
            // Insert new elements immediately behind head.
            foreach (var child in childrenSelector(headValue))
                localTail = localTail.Append(child);
            // Splice on the old tail, if there was one
            if (second != null) localTail.Next = second;
            // Pop the head
            yield return headValue;
            head = head.Next; 
        }
    }
    public class ForwardLink<T> {
        public T Value { get; private set; }
        public ForwardLink<T> Next { get; set; }
        public ForwardLink(T value) { Value = value; }
        public ForwardLink(IEnumerable<T> values) { 
            bool firstElement = true;
            ForwardLink<T> tail = null;
            foreach (T item in values)
            {
                if (firstElement)
                {
                    Value = item;
                    firstElement = false;
                    tail = this;
                }
                else
                {
                    tail = tail.Append(item);
                }
            }
        }
        public ForwardLink<T> Append(T value) {
            return Next = new ForwardLink<T>(value);
        } 
    }
