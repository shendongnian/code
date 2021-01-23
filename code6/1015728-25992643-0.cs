    public enum Color { Red, Yellow, Green, Blue }    
    public class ColorSet : HashSet<Color> {}
    
    private void setColors(ColorSet colors = null)
    {
        if (colors == null)
            colors = new ColorSet {Color.Red, Color.Green};
    
        ....
    }
