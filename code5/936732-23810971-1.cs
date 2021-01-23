    public static IEnumerable<DependencyObject> GetLogicalChild(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return;
    
            var q = new Queue<DependencyObject>();
            foreach (var w in LogicalTreeHelper.GetChildren(item))
            {
                var t = w as DependencyObject;
                if (condition(t))
                    yield return t;
                q.Enqueue(t);
            }
    
            while (q.Count > 0)
            {
                var subchild = q.Dequeue();
                foreach (var w in LogicalTreeHelper.GetChildren(subchild))
                {
                    var t = w as DependencyObject;
                    if (condition(t))
                        yield return t;
                    q.Enqueue(t);
                }
            }
            return null;
        }
