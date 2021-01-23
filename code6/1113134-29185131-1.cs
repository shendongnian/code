    interface IDrawXYZ {
    void DrawShape(Graphics g, int x, int y);
    }
    
    String srcCode =@"
    using System;
    using System.Drawing;
    public class MyObject1 : IDrawXYZ {
       //...
    }";
