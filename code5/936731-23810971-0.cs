            public static IEnumerable<DependencyObject> GetVisualChild(DependencyObject item, Func<DependencyObject, bool> condition)
            {
                if (item == null)
                    return;
    
                var q = new Queue<DependencyObject>();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(item); i++)
                {
                    var t = VisualTreeHelper.GetChild(item, i);
                    if (condition(t))
                        yield return t;
                    q.Enqueue(t);
                }
    
                while (q.Count > 0)
                {
                    var subchild = q.Dequeue();
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(subchild); i++)
                    {
                        var t = VisualTreeHelper.GetChild(subchild, i);
                        if (condition(t))
                            yield return t;
                        q.Enqueue(t);
                    }
                }
                return null;
            }
