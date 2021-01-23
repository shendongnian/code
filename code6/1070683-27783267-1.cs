    object v = rk.GetValue("width");
    if (v != null)
    {
        //TryParse would be even better.
        this.Width = Int32.Parse((string)v);
    }
