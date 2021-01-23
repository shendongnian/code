    private static IEnumerable<Control> FlattenControlTree(Control control)
    {
        if (IsTypeOf<YourBasePage>(control))
        {
            yield return control;
        }
        foreach (Control contr in control.Controls.Cast<Control>().SelectMany((c) => FlattenControlTree(c)))
        {
            if (IsTypeOf<Control>(YourBasePage))
            {
                yield return contr;
            }
        }
    }
    private static bool IsTypeOf<T>(object obj) where T : class
    {
        return obj is T;
    }
