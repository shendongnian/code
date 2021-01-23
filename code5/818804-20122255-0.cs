    public static IEnumerable<Control> FindAll(this ControlCollection collection)
    {
        foreach (Control item in collection)
        {
            yield return item;
    
            if (item.HasControls())
            {
                foreach (var subItem in item.Controls.FindAll())
                {
                    yield return subItem;
                }
            }
        }
    }
