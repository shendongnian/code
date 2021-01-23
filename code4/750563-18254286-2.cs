    public static IEnumerable<T> FindControls<T>(this Control control, bool recurse) where T : Control
    {
        List<T> found = new List<T>();
        Action<Control> search = null;
        search = ctrl =>
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (typeof(T).IsAssignableFrom(child.GetType()))
                    {
                        found.Add((T)child);
                    }
                    if (recurse)
                    {
                        search(child);
                    }
                }
            };
        search(control);
        return found;
    }
