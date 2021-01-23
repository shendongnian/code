    Expander expander = FindMyParentHelper<Expander>.FindAncestor(boton);
    public static class FindMyParentHelper<T> where T : DependencyObject
    {
        public static T FindAncestor(DependencyObject dependencyObject)
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
 
            if (parent == null) return null;
 
            var parentT = parent as T;
            return parentT ?? FindAncestor(parent);
        }
    }
