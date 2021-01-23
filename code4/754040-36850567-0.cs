    public int ChildrenCount(ContentPlaceHolder placeholder)
    {
        int total = 0;
        total += placeholder.Controls.OfType<Control>().Where(x => 
            (!(x is ContentPlaceHolder) && !(x is LiteralControl)) ||
            (x is LiteralControl && !string.IsNullOrWhiteSpace(((LiteralControl)x).Text))
        ).Count();
        foreach (var child in placeholder.Controls.OfType<ContentPlaceHolder>())
	        total += ChildrenCount(child);
        return total;
    }
