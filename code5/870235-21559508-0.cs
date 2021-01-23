    public static IEnumerable<T> GetAllControlsOfType<T>(Control parent) where T: Control {
        foreach (Control c in parent.Controls) {
            if (c is T)
                yield return c as T;
            if (c.HasControls())
                foreach (T innerControl in GetAllControlsOfType<T>(c))
                    yield return innerControl;
        }
    }
