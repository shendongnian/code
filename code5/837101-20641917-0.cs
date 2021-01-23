    public class Leveled<T> 
    {
        public T Item {get; set;}
        public int Level {get; set;}
    }
    public static IEnumerable<Leveled<T>> ToLeveled<T>(this IEnumerable<T> sequence,
                                                int level)
    {
       return sequence.Select(item => new Leveled<T>{ Item = item, Level = level});
    }
    public static IEnumerable<Leveled<T>> FlattenLeveled<T>(this IEnumerable<T> sequence, 
                                                Func<T, IEnumerable<T>> childFetcher)
    {
        var itemsToYield = new Queue<Leveled<T>>(sequence.ToLeveled(0));
        while (itemsToYield.Count > 0)
        {
            var leveledItem = itemsToYield.Dequeue();
            yield return leveledItem.Item;
    
            var children = childFetcher(leveledItem.Item);
            if (children != null)
            { 
                foreach (var child in children) 
                   itemsToYield.Enqueue(child.ToLeveled(leveledItem.Level+1));
            }
        }
    }
