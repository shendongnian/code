    try
    {
         name = x.Name;
        // Wrong
        // value = x.GetType().GetProperty(x.Name).GetValue(x, null).ToString();
        // Correct
        value = x.GetValue(i, null).ToString();
    }
    catch (Exception e)
    {
        <p>@e</p>
    }
