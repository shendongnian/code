    public enum colors
    {
     Red = 1,
     green = 2,
     blue = 3
    }
     
    colors col = selectedCol; // selectedCol is the color you select for your Applications
    object val = (col != null) ? Convert.ChangeType(col, typeof(string)) : 0;
