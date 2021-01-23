    public class InitRectangleEventArgs : EventArgs {
       public Rectangle Rectangle {get;set;}
    }
    public delegate void InitRectangleEventHandler(object sender, InitRectangleEventArgs e);
    public event InitRectangleEventHandler InitRectangle;
    public DrawRectangle(int x, int y, int width, int height)
    {
        rectangle.X = x;
        rectangle.Y = y;
        rectangle.Width = width;
        rectangle.Height = height;
        if(InitRectangle != null) InitRectangle(this, new InitRectangleEventArgs { Rectangle = new Rectangle(x,y,width,height)});
        Initialize();
    }
    //To use it, just subscribe the event so that you can know the 
    //info of the Rectangle everytime it is initialized
    InitRectangle += (s,e) => {
      //Get the info from the Rectangle property of e:   e.Rectangle
      //....
    };
    
    
