    public static class DependencyObjectExt
    {
            public static DependencyObject GetChild(this DependencyObject @this, int childIndex)
            {
                return VisualTreeHelper.GetChild(@this, childIndex);
            }
    
            public static IEnumerable<DependencyObject> GetChildren(this DependencyObject @this)
            {
                for(int i = 0; i < VisualTreeHelper.GetChildrenCount(@this); i++)
                {
                    yield return @this.GetChild(i);
                }
            }
    
            public static IEnumerable<T> FindChildrenOfType<T>(this DependencyObject @this) where T : DependencyObject
            {
                foreach(var child in @this.GetChildren())
                {
                    if(child is T)
                    {
                        yield return child as T;
                    }
                }
            }
    
            public static IEnumerable<T> FindDescendantsOfType<T>(this DependencyObject @this) where T : DependencyObject
            {
                IEnumerable<T> result = Enumerable.Empty<T>();
    
                foreach(var child in @this.GetChildren())
                {
                    if(child is T)
                    {
                        result = result.Concat(child.ToEnumerable().Cast<T>());
                    }
                    result = result.Concat(child.FindDescendantsOfType<T>());
                }
    
                return result;
            }
    }
