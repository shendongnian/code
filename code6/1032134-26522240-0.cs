    private static List<T> GetControls<T>(ControlCollection cCol, List<T> results) where T : WebControl
    {
        foreach (Control control in cCol)
        {
            if (control is T)
                results.Add((T)control);
            if (control.HasControls())
                GetControls<T>(control.Controls, results);
        }
        return results;
    }
    public static List<T> GetControls<T>(ControlCollection cCol) where T : WebControl
    {
        return GetControls(cCol, new List<T>());
    }
