public class BaseShape
{
    public List<BaseStyle> Styles {get;}
    //...
    public void Draw()
    {
        this.DrawMe();
        foreach(var style in Styles)
        {
           style.Draw(this);
        }   
    }
    public void AddStyle(BaseStyle style){this.Styles.Add(style);}
    public void RemoveStyle(BaseStyle style){this.Styles.Remove(style);}
    protected abstract void DrawMe(); // Child class (eg Circle) knows how to draw the shape
}
public class BorderStyle : BaseStyle
{
    public override void Draw(BaseShape shape)
    {
       // Draw a border as you would in your decorator.
    }
}
This will allow you to add and remove styles as well as share style instances where you know up front that styles will be the same. For example the outline that indicates that the shape is selected/active.
public void Main()
{
    var border = new BorderStyle(); // shared
    
    var circle = new Circle();
    circle.AddStyle(border);
    var square = new Square();
    square.AddStyle(border);
    // Later you want to remove the border and add a drop shadow:
    square.RemoveStyle(border);
    square.AddStyle(new DropShadowStyle());
}
This will also allow some optimizations for example only redrawing modifiers if their attributes have changed. For example if the border width gets updated.
This will likely also work nicely with your command system as `Execute()` can add the style and potentially `Undo()` could have the inverse algorithm i.e. remove the style.
Another benefit (depending on what your app allows) is that styles are completely separated from whatever it is that they decorate. For example, say a user creates a red 4px border style and wants to save it for future use, you could easily serialize this style and use it as a template to apply to various shapes in the future. 
