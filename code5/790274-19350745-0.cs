    IEnumerable array = val as IEnumerable;
    if (array != null)
    {
        foreach (var element in array)
        {
            MessageBox.Show(element.ToString());
        }
    }
