    public double Parse(...)
    {
        double value = 0;
        string text = ((TextBox)control.Items[someRow].FindControl("txtControl")).Text;
        double.TryParse(text, out value);
        return value;
    }
