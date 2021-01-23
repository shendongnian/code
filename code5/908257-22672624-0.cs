    public class MyClass
    {
    
    List<Point> pts = new List<Point>();//This way the member persists
    
    public void OnClick(TypeName i, EventArgs e)//whatever params are..
    {
        Point recordpoint = new Point(i.X, i.Y);//create element
        pts.Add(recordpoint);//insert into collection
    }
    
    }
